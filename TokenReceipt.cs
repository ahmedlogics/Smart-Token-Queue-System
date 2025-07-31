using System;
using System.Drawing;
using System.IO;
using System.Windows.Forms;
using iTextSharp.text;
using iTextSharp.text.pdf;
using QRCoder;

namespace WindowsFormsApp1
{
    public partial class Form7 : Form
    {
        private string tokenID, tokenNumber, department, branch, category, date, timeSlot, amount;

        public Form7(string tokenID, string tokenNumber, string department, string branch, string category, string date, string timeSlot, int amount)
        {
            InitializeComponent();

            this.tokenID = tokenID;
            this.tokenNumber = tokenNumber;
            this.department = department;
            this.branch = branch;
            this.category = category;
            this.date = date;
            this.timeSlot = timeSlot;
            this.amount = amount.ToString();

            // Set values on labels
            lblTokenID.Text = tokenID;
            lblToken.Text = tokenNumber;
            lblDepartment.Text = department;
            lblBranch.Text = branch;
            lblCategory.Text = category;
            lblDate.Text = date;
            lblTimeSlot.Text = timeSlot;
            lblAmount.Text = this.amount;

            GenerateQRCode();
        }

        private void GenerateQRCode()
        {
            string qrData = $"Token#: {tokenNumber}\nDept: {department}\nDate: {date}\nTime: {timeSlot}";
            QRCodeGenerator qrGenerator = new QRCodeGenerator();
            QRCodeData qrCodeData = qrGenerator.CreateQrCode(qrData, QRCodeGenerator.ECCLevel.Q);
            QRCode qrCode = new QRCode(qrCodeData);
            Bitmap qrCodeImage = qrCode.GetGraphic(5);

            pictureBoxQR.Image = qrCodeImage;
        }

        private void BtnSavePdf_Click(object sender, EventArgs e)
        {
            SaveFileDialog saveDialog = new SaveFileDialog
            {
                Filter = "PDF files (*.pdf)|*.pdf",
                FileName = $"Token_{lblToken.Text}.pdf"
            };

            if (saveDialog.ShowDialog() == DialogResult.OK)
            {
                try
                {
                    using (FileStream stream = new FileStream(saveDialog.FileName, FileMode.Create))
                    {
                        Document pdfDoc = new Document(PageSize.A5, 25, 25, 30, 30);
                        PdfWriter writer = PdfWriter.GetInstance(pdfDoc, stream);
                        pdfDoc.Open();

                        var titleFont = FontFactory.GetFont(FontFactory.HELVETICA_BOLD, 16);
                        Paragraph title = new Paragraph("GOVERNMENT DEPARTMENT TOKEN RECEIPT", titleFont);
                        title.Alignment = Element.ALIGN_CENTER;
                        pdfDoc.Add(title);
                        pdfDoc.Add(new Paragraph("\n"));

                        PdfPTable table = new PdfPTable(2) { WidthPercentage = 100 };

                        table.AddCell("Token ID:");
                        table.AddCell(tokenID);

                        table.AddCell("Token Number:");
                        table.AddCell(tokenNumber);

                        table.AddCell("Department:");
                        table.AddCell(department);

                        table.AddCell("Branch:");
                        table.AddCell(branch);

                        table.AddCell("Category:");
                        table.AddCell(category);

                        table.AddCell("Date:");
                        table.AddCell(date);

                        table.AddCell("Time Slot:");
                        table.AddCell(timeSlot);

                        table.AddCell("Amount Paid:");
                        table.AddCell(amount + " PKR");

                        pdfDoc.Add(table);
                        pdfDoc.Add(new Paragraph("\n"));

                        // QR Code in PDF
                        if (pictureBoxQR.Image != null)
                        {
                            using (MemoryStream qrStream = new MemoryStream())
                            {
                                pictureBoxQR.Image.Save(qrStream, System.Drawing.Imaging.ImageFormat.Png);
                                iTextSharp.text.Image qrImg = iTextSharp.text.Image.GetInstance(qrStream.ToArray());
                                qrImg.Alignment = Element.ALIGN_CENTER;
                                qrImg.ScaleAbsolute(100f, 100f);
                                pdfDoc.Add(qrImg);
                            }
                        }

                        pdfDoc.Add(new Paragraph("\n\nThank you for using our token system.", FontFactory.GetFont(FontFactory.HELVETICA_OBLIQUE, 10)));
                        pdfDoc.Close();
                    }

                    MessageBox.Show("PDF saved successfully.", "Success", MessageBoxButtons.OK, MessageBoxIcon.Information);
                }
                catch (Exception ex)
                {
                    MessageBox.Show("Error saving PDF: " + ex.Message);
                }
            }
        }

        private void BtnNext_Click(object sender, EventArgs e)
        {
            Form5 form = new Form5(tokenID, tokenNumber, department, branch, category, date, timeSlot);
            form.Show();
            this.Hide();
        }
    }
}
