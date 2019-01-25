namespace Sever
{
    partial class CM_Server
    {
        /// <summary>
        /// 필수 디자이너 변수입니다.
        /// </summary>
        private System.ComponentModel.IContainer components = null;

        /// <summary>
        /// 사용 중인 모든 리소스를 정리합니다.
        /// </summary>
        /// <param name="disposing">관리되는 리소스를 삭제해야 하면 true이고, 그렇지 않으면 false입니다.</param>
        protected override void Dispose(bool disposing)
        {
            if (disposing && (components != null))
            {
                components.Dispose();
            }
            base.Dispose(disposing);
        }

        #region Windows Form 디자이너에서 생성한 코드

        /// <summary>
        /// 디자이너 지원에 필요한 메서드입니다. 
        /// 이 메서드의 내용을 코드 편집기로 수정하지 마세요.
        /// </summary>
        private void InitializeComponent()
        {
            this.Log_text = new System.Windows.Forms.TextBox();
            this.SuspendLayout();
            // 
            // Log_text
            // 
            this.Log_text.Location = new System.Drawing.Point(0, 0);
            this.Log_text.Multiline = true;
            this.Log_text.Name = "Log_text";
            this.Log_text.ScrollBars = System.Windows.Forms.ScrollBars.Vertical;
            this.Log_text.Size = new System.Drawing.Size(674, 463);
            this.Log_text.TabIndex = 0;
            // 
            // CM_Server
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(8F, 15F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(674, 462);
            this.Controls.Add(this.Log_text);
            this.Name = "CM_Server";
            this.Text = "Form1";
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.TextBox Log_text;
    }
}

