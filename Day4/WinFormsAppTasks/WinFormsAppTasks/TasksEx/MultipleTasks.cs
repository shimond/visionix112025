using Microsoft.VisualBasic;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace WinFormsAppTasks.TasksEx
{
    public partial class MultipleTasks : Form
    {
        public MultipleTasks()
        {
            InitializeComponent();
        }

        private void MultipleTasks_Load(object sender, EventArgs e)
        {
            // 1. stop after timeout
            // 2. race between tasks

            var progress = new Progress<string>(x => this.Text = x);

            CancellationTokenSource cancelSourceTimeOut = new CancellationTokenSource(5000);
            CancellationTokenSource cancelSourceManual = new CancellationTokenSource(5000);


            cancelSourceManual.Token.Register(() =>
            {
                MessageBox.Show("Task was cancelled manually.");
            });

            var cts = CancellationTokenSource.CreateLinkedTokenSource(
                cancelSourceTimeOut.Token,
                cancelSourceManual.Token);

            Task.Factory.StartNew(async () =>
            {
                int count = 0;
                while (true)
                {
                    count++;
                    ((IProgress<string>)progress).Report($"Count: {count}");
                    cts.Token.ThrowIfCancellationRequested();
                    await Task.Delay(1000);
                    // do work
                }

            }, cts.Token);
        }

        private async void btnTests_Click(object sender, EventArgs e)
        {
            using var cts = new CancellationTokenSource();
            var token = cts.Token;

            Task<string> TaskA() => Task.Run(async () =>
            {
                for (int i = 0; i < 5; i++)
                {
                    token.ThrowIfCancellationRequested();
                    await Task.Delay(300, token); // fake work
                }
                return "Task A finished";
            }, token);

            Task<string> TaskB() => Task.Run(async () =>
            {
                for (int i = 0; i < 8; i++)
                {
                    token.ThrowIfCancellationRequested();
                    await Task.Delay(200, token); // fake work
                }
                return "Task B finished";
            }, token);

            Task<string> TaskC() => Task.Run(async () =>
            {
                for (int i = 0; i < 10; i++)
                {
                    token.ThrowIfCancellationRequested();
                    await Task.Delay(150, token); // fake work
                }
                return "Task C finished";
            }, token);

            var t1 = TaskA();
            var t2 = TaskB();
            var t3 = TaskC();
            Task<string>[] tasks = { t1, t2, t3 };

            // Wait for any to complete
            Task<string> first = await Task.WhenAny(tasks);

            string firstResult = string.Empty;
            try
            {
                // Get the result of the first completed task
                firstResult = await first;
            }
            catch (OperationCanceledException)
            {
                firstResult = "First task was canceled";
            }
            catch (Exception ex)
            {
                firstResult = $"First task faulted: {ex.Message}";
            }

            // Cancel remaining tasks
            cts.Cancel();

            // Optionally observe cancellations to avoid unobserved exceptions
            try { await Task.WhenAll(tasks); } catch { /* ignore remaining task cancellations/faults */ }

            MessageBox.Show(firstResult);
        }

        private void btnTest_Click(object sender, EventArgs e)
        {
            
        }
    }
}
