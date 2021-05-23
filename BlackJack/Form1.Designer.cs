
namespace BlackJack
{
    partial class Form1
    {
        /// <summary>
        /// Required designer variable.
        /// </summary>
        private System.ComponentModel.IContainer components = null;

        /// <summary>
        /// Clean up any resources being used.
        /// </summary>
        /// <param name="disposing">true if managed resources should be disposed; otherwise, false.</param>
        protected override void Dispose(bool disposing)
        {
            if (disposing && (components != null))
            {
                components.Dispose();
            }
            base.Dispose(disposing);
        }

        #region Windows Form Designer generated code

        /// <summary>
        /// Required method for Designer support - do not modify
        /// the contents of this method with the code editor.
        /// </summary>
        private void InitializeComponent()
        {
            this.hitBt = new System.Windows.Forms.Button();
            this.splitbt = new System.Windows.Forms.Button();
            this.dealbt = new System.Windows.Forms.Button();
            this.standbt = new System.Windows.Forms.Button();
            this.playerCard1 = new System.Windows.Forms.PictureBox();
            this.playerCard2 = new System.Windows.Forms.PictureBox();
            this.dealerCard1 = new System.Windows.Forms.PictureBox();
            this.dealerCard2 = new System.Windows.Forms.PictureBox();
            this.highLightCard1 = new System.Windows.Forms.PictureBox();
            this.hightLightCard2 = new System.Windows.Forms.PictureBox();
            this.playersHitCardIB = new System.Windows.Forms.PictureBox();
            this.dealersHitCardIB = new System.Windows.Forms.PictureBox();
            this.playerHandValueLB = new System.Windows.Forms.Label();
            this.playersSplitHandTwoValueTB = new System.Windows.Forms.Label();
            this.playersSplitHandOneValueTB = new System.Windows.Forms.Label();
            ((System.ComponentModel.ISupportInitialize)(this.playerCard1)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.playerCard2)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.dealerCard1)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.dealerCard2)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.highLightCard1)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.hightLightCard2)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.playersHitCardIB)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.dealersHitCardIB)).BeginInit();
            this.SuspendLayout();
            // 
            // hitBt
            // 
            this.hitBt.Location = new System.Drawing.Point(186, 1038);
            this.hitBt.Name = "hitBt";
            this.hitBt.Size = new System.Drawing.Size(146, 82);
            this.hitBt.TabIndex = 0;
            this.hitBt.Text = "Hit";
            this.hitBt.UseVisualStyleBackColor = true;
            this.hitBt.Click += new System.EventHandler(this.hitBt_Click);
            // 
            // splitbt
            // 
            this.splitbt.Location = new System.Drawing.Point(37, 1196);
            this.splitbt.Name = "splitbt";
            this.splitbt.Size = new System.Drawing.Size(101, 47);
            this.splitbt.TabIndex = 1;
            this.splitbt.Text = "Split";
            this.splitbt.UseVisualStyleBackColor = true;
            this.splitbt.Click += new System.EventHandler(this.splitbt_Click);
            // 
            // dealbt
            // 
            this.dealbt.Location = new System.Drawing.Point(404, 1158);
            this.dealbt.Name = "dealbt";
            this.dealbt.Size = new System.Drawing.Size(190, 85);
            this.dealbt.TabIndex = 2;
            this.dealbt.Text = "Deal";
            this.dealbt.UseVisualStyleBackColor = true;
            this.dealbt.Click += new System.EventHandler(this.dealbt_Click);
            // 
            // standbt
            // 
            this.standbt.Location = new System.Drawing.Point(643, 1023);
            this.standbt.Name = "standbt";
            this.standbt.Size = new System.Drawing.Size(168, 97);
            this.standbt.TabIndex = 3;
            this.standbt.Text = "Stand";
            this.standbt.UseVisualStyleBackColor = true;
            this.standbt.Click += new System.EventHandler(this.standbt_Click);
            // 
            // playerCard1
            // 
            this.playerCard1.BackColor = System.Drawing.Color.Transparent;
            this.playerCard1.Location = new System.Drawing.Point(134, 560);
            this.playerCard1.Name = "playerCard1";
            this.playerCard1.Size = new System.Drawing.Size(342, 427);
            this.playerCard1.TabIndex = 6;
            this.playerCard1.TabStop = false;
            // 
            // playerCard2
            // 
            this.playerCard2.BackColor = System.Drawing.Color.Transparent;
            this.playerCard2.Location = new System.Drawing.Point(536, 560);
            this.playerCard2.Name = "playerCard2";
            this.playerCard2.Size = new System.Drawing.Size(342, 427);
            this.playerCard2.TabIndex = 7;
            this.playerCard2.TabStop = false;
            // 
            // dealerCard1
            // 
            this.dealerCard1.BackColor = System.Drawing.Color.Transparent;
            this.dealerCard1.Location = new System.Drawing.Point(204, 72);
            this.dealerCard1.Name = "dealerCard1";
            this.dealerCard1.Size = new System.Drawing.Size(342, 427);
            this.dealerCard1.TabIndex = 8;
            this.dealerCard1.TabStop = false;
            // 
            // dealerCard2
            // 
            this.dealerCard2.BackColor = System.Drawing.Color.Transparent;
            this.dealerCard2.Location = new System.Drawing.Point(421, 72);
            this.dealerCard2.Name = "dealerCard2";
            this.dealerCard2.Size = new System.Drawing.Size(342, 427);
            this.dealerCard2.TabIndex = 9;
            this.dealerCard2.TabStop = false;
            // 
            // highLightCard1
            // 
            this.highLightCard1.BackColor = System.Drawing.Color.Gold;
            this.highLightCard1.BorderStyle = System.Windows.Forms.BorderStyle.Fixed3D;
            this.highLightCard1.Location = new System.Drawing.Point(517, 542);
            this.highLightCard1.Name = "highLightCard1";
            this.highLightCard1.Size = new System.Drawing.Size(380, 464);
            this.highLightCard1.TabIndex = 10;
            this.highLightCard1.TabStop = false;
            // 
            // hightLightCard2
            // 
            this.hightLightCard2.BackColor = System.Drawing.Color.Gold;
            this.hightLightCard2.BorderStyle = System.Windows.Forms.BorderStyle.Fixed3D;
            this.hightLightCard2.Location = new System.Drawing.Point(117, 542);
            this.hightLightCard2.Name = "hightLightCard2";
            this.hightLightCard2.Size = new System.Drawing.Size(379, 464);
            this.hightLightCard2.TabIndex = 11;
            this.hightLightCard2.TabStop = false;
            // 
            // playersHitCardIB
            // 
            this.playersHitCardIB.BackColor = System.Drawing.Color.White;
            this.playersHitCardIB.Location = new System.Drawing.Point(338, 560);
            this.playersHitCardIB.Name = "playersHitCardIB";
            this.playersHitCardIB.Size = new System.Drawing.Size(343, 427);
            this.playersHitCardIB.TabIndex = 12;
            this.playersHitCardIB.TabStop = false;
            // 
            // dealersHitCardIB
            // 
            this.dealersHitCardIB.BackColor = System.Drawing.Color.White;
            this.dealersHitCardIB.Location = new System.Drawing.Point(313, 72);
            this.dealersHitCardIB.Name = "dealersHitCardIB";
            this.dealersHitCardIB.Size = new System.Drawing.Size(343, 427);
            this.dealersHitCardIB.TabIndex = 13;
            this.dealersHitCardIB.TabStop = false;
            // 
            // playerHandValueLB
            // 
            this.playerHandValueLB.AutoSize = true;
            this.playerHandValueLB.BackColor = System.Drawing.Color.White;
            this.playerHandValueLB.Font = new System.Drawing.Font("Microsoft Sans Serif", 14F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.playerHandValueLB.Location = new System.Drawing.Point(485, 1059);
            this.playerHandValueLB.Name = "playerHandValueLB";
            this.playerHandValueLB.Size = new System.Drawing.Size(0, 32);
            this.playerHandValueLB.TabIndex = 14;
            // 
            // playersSplitHandTwoValueTB
            // 
            this.playersSplitHandTwoValueTB.AutoSize = true;
            this.playersSplitHandTwoValueTB.BackColor = System.Drawing.Color.White;
            this.playersSplitHandTwoValueTB.Font = new System.Drawing.Font("Microsoft Sans Serif", 14F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.playersSplitHandTwoValueTB.Location = new System.Drawing.Point(258, 1003);
            this.playersSplitHandTwoValueTB.Name = "playersSplitHandTwoValueTB";
            this.playersSplitHandTwoValueTB.Size = new System.Drawing.Size(0, 32);
            this.playersSplitHandTwoValueTB.TabIndex = 15;
            // 
            // playersSplitHandOneValueTB
            // 
            this.playersSplitHandOneValueTB.AutoSize = true;
            this.playersSplitHandOneValueTB.BackColor = System.Drawing.Color.White;
            this.playersSplitHandOneValueTB.Font = new System.Drawing.Font("Microsoft Sans Serif", 14F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.playersSplitHandOneValueTB.Location = new System.Drawing.Point(711, 988);
            this.playersSplitHandOneValueTB.Name = "playersSplitHandOneValueTB";
            this.playersSplitHandOneValueTB.Size = new System.Drawing.Size(0, 32);
            this.playersSplitHandOneValueTB.TabIndex = 16;
            // 
            // Form1
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(9F, 20F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(0)))), ((int)(((byte)(64)))), ((int)(((byte)(0)))));
            this.ClientSize = new System.Drawing.Size(1032, 1285);
            this.Controls.Add(this.playersSplitHandOneValueTB);
            this.Controls.Add(this.playersSplitHandTwoValueTB);
            this.Controls.Add(this.playerHandValueLB);
            this.Controls.Add(this.dealersHitCardIB);
            this.Controls.Add(this.playersHitCardIB);
            this.Controls.Add(this.dealerCard2);
            this.Controls.Add(this.dealerCard1);
            this.Controls.Add(this.playerCard2);
            this.Controls.Add(this.standbt);
            this.Controls.Add(this.dealbt);
            this.Controls.Add(this.splitbt);
            this.Controls.Add(this.hitBt);
            this.Controls.Add(this.playerCard1);
            this.Controls.Add(this.highLightCard1);
            this.Controls.Add(this.hightLightCard2);
            this.Name = "Form1";
            this.Text = "Black Jack";
            ((System.ComponentModel.ISupportInitialize)(this.playerCard1)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.playerCard2)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.dealerCard1)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.dealerCard2)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.highLightCard1)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.hightLightCard2)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.playersHitCardIB)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.dealersHitCardIB)).EndInit();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.Button hitBt;
        private System.Windows.Forms.Button splitbt;
        private System.Windows.Forms.Button dealbt;
        private System.Windows.Forms.Button standbt;
        private System.Windows.Forms.PictureBox playerCard1;
        private System.Windows.Forms.PictureBox playerCard2;
        private System.Windows.Forms.PictureBox dealerCard1;
        private System.Windows.Forms.PictureBox dealerCard2;
        private System.Windows.Forms.PictureBox highLightCard1;
        private System.Windows.Forms.PictureBox hightLightCard2;
        public System.Windows.Forms.PictureBox playersHitCardIB;
        public System.Windows.Forms.PictureBox dealersHitCardIB;
        private System.Windows.Forms.Label playerHandValueLB;
        private System.Windows.Forms.Label playersSplitHandTwoValueTB;
        private System.Windows.Forms.Label playersSplitHandOneValueTB;
    }
}

