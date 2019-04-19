/*******************************************************************************
 *  Copyright 2012-2018 Amazon.com, Inc. or its affiliates. All Rights Reserved.
 *  Licensed under the Apache License, Version 2.0 (the "License"). You may not use
 *  this file except in compliance with the License. A copy of the License is located at
 *
 *  http://aws.amazon.com/apache2.0
 *
 *  or in the "license" file accompanying this file.
 *  This file is distributed on an "AS IS" BASIS, WITHOUT WARRANTIES OR
 *  CONDITIONS OF ANY KIND, either express or implied. See the License for the
 *  specific language governing permissions and limitations under the License.
 * *****************************************************************************
 *
 *  AWS Tools for Windows (TM) PowerShell (TM)
 *
 */

using System;
using System.Collections.Generic;
using System.Linq;
using System.Management.Automation;
using System.Text;
using Amazon.PowerShell.Common;
using Amazon.Runtime;
using Amazon.PinpointEmail;
using Amazon.PinpointEmail.Model;

namespace Amazon.PowerShell.Cmdlets.PINE
{
    /// <summary>
    /// Create a new predictive inbox placement test. Predictive inbox placement tests can
    /// help you predict how your messages will be handled by various email providers around
    /// the world. When you perform a predictive inbox placement test, you provide a sample
    /// message that contains the content that you plan to send to your customers. Amazon
    /// Pinpoint then sends that message to special email addresses spread across several
    /// major email providers. After about 24 hours, the test is complete, and you can use
    /// the <code>GetDeliverabilityTestReport</code> operation to view the results of the
    /// test.
    /// </summary>
    [Cmdlet("New", "PINEDeliverabilityTestReport", SupportsShouldProcess = true, ConfirmImpact = ConfirmImpact.Medium)]
    [OutputType("Amazon.PinpointEmail.Model.CreateDeliverabilityTestReportResponse")]
    [AWSCmdlet("Calls the Amazon Pinpoint Email CreateDeliverabilityTestReport API operation.", Operation = new[] {"CreateDeliverabilityTestReport"})]
    [AWSCmdletOutput("Amazon.PinpointEmail.Model.CreateDeliverabilityTestReportResponse",
        "This cmdlet returns a Amazon.PinpointEmail.Model.CreateDeliverabilityTestReportResponse object containing multiple properties. The object can also be referenced from properties attached to the cmdlet entry in the $AWSHistory stack."
    )]
    public partial class NewPINEDeliverabilityTestReportCmdlet : AmazonPinpointEmailClientCmdlet, IExecutor
    {
        
        #region Parameter Html_Charset
        /// <summary>
        /// <para>
        /// <para>The character set for the content. Because of the constraints of the SMTP protocol,
        /// Amazon Pinpoint uses 7-bit ASCII by default. If the text includes characters outside
        /// of the ASCII range, you have to specify a character set. For example, you could specify
        /// <code>UTF-8</code>, <code>ISO-8859-1</code>, or <code>Shift_JIS</code>.</para>
        /// </para>
        /// </summary>
        [System.Management.Automation.Parameter]
        [Alias("Content_Simple_Body_Html_Charset")]
        public System.String Html_Charset { get; set; }
        #endregion
        
        #region Parameter Text_Charset
        /// <summary>
        /// <para>
        /// <para>The character set for the content. Because of the constraints of the SMTP protocol,
        /// Amazon Pinpoint uses 7-bit ASCII by default. If the text includes characters outside
        /// of the ASCII range, you have to specify a character set. For example, you could specify
        /// <code>UTF-8</code>, <code>ISO-8859-1</code>, or <code>Shift_JIS</code>.</para>
        /// </para>
        /// </summary>
        [System.Management.Automation.Parameter]
        [Alias("Content_Simple_Body_Text_Charset")]
        public System.String Text_Charset { get; set; }
        #endregion
        
        #region Parameter Subject_Charset
        /// <summary>
        /// <para>
        /// <para>The character set for the content. Because of the constraints of the SMTP protocol,
        /// Amazon Pinpoint uses 7-bit ASCII by default. If the text includes characters outside
        /// of the ASCII range, you have to specify a character set. For example, you could specify
        /// <code>UTF-8</code>, <code>ISO-8859-1</code>, or <code>Shift_JIS</code>.</para>
        /// </para>
        /// </summary>
        [System.Management.Automation.Parameter]
        [Alias("Content_Simple_Subject_Charset")]
        public System.String Subject_Charset { get; set; }
        #endregion
        
        #region Parameter Raw_Data
        /// <summary>
        /// <para>
        /// <para>The raw email message. The message has to meet the following criteria:</para><ul><li><para>The message has to contain a header and a body, separated by one blank line.</para></li><li><para>All of the required header fields must be present in the message.</para></li><li><para>Each part of a multipart MIME message must be formatted properly.</para></li><li><para>Attachments must be in a file format that Amazon Pinpoint supports. </para></li><li><para>The entire message must be Base64 encoded.</para></li><li><para>If any of the MIME parts in your message contain content that is outside of the 7-bit
        /// ASCII character range, you should encode that content to ensure that recipients' email
        /// clients render the message properly.</para></li><li><para>The length of any single line of text in the message can't exceed 1,000 characters.
        /// This restriction is defined in <a href="https://tools.ietf.org/html/rfc5321">RFC 5321</a>.</para></li></ul>
        /// </para>
        /// </summary>
        [System.Management.Automation.Parameter]
        [Alias("Content_Raw_Data")]
        public byte[] Raw_Data { get; set; }
        #endregion
        
        #region Parameter Html_Data
        /// <summary>
        /// <para>
        /// <para>The content of the message itself.</para>
        /// </para>
        /// </summary>
        [System.Management.Automation.Parameter]
        [Alias("Content_Simple_Body_Html_Data")]
        public System.String Html_Data { get; set; }
        #endregion
        
        #region Parameter Text_Data
        /// <summary>
        /// <para>
        /// <para>The content of the message itself.</para>
        /// </para>
        /// </summary>
        [System.Management.Automation.Parameter]
        [Alias("Content_Simple_Body_Text_Data")]
        public System.String Text_Data { get; set; }
        #endregion
        
        #region Parameter Subject_Data
        /// <summary>
        /// <para>
        /// <para>The content of the message itself.</para>
        /// </para>
        /// </summary>
        [System.Management.Automation.Parameter]
        [Alias("Content_Simple_Subject_Data")]
        public System.String Subject_Data { get; set; }
        #endregion
        
        #region Parameter FromEmailAddress
        /// <summary>
        /// <para>
        /// <para>The email address that the predictive inbox placement test email was sent from.</para>
        /// </para>
        /// </summary>
        [System.Management.Automation.Parameter(Position = 0, ValueFromPipeline = true)]
        public System.String FromEmailAddress { get; set; }
        #endregion
        
        #region Parameter ReportName
        /// <summary>
        /// <para>
        /// <para>A unique name that helps you to identify the predictive inbox placement test when
        /// you retrieve the results.</para>
        /// </para>
        /// </summary>
        [System.Management.Automation.Parameter]
        public System.String ReportName { get; set; }
        #endregion
        
        #region Parameter Tag
        /// <summary>
        /// <para>
        /// <para>An object that defines the tags (keys and values) that you want to associate with
        /// the predictive inbox placement test.</para>
        /// </para>
        /// </summary>
        [System.Management.Automation.Parameter]
        [Alias("Tags")]
        public Amazon.PinpointEmail.Model.Tag[] Tag { get; set; }
        #endregion
        
        #region Parameter Force
        /// <summary>
        /// This parameter overrides confirmation prompts to force 
        /// the cmdlet to continue its operation. This parameter should always
        /// be used with caution.
        /// </summary>
        [System.Management.Automation.Parameter]
        public SwitchParameter Force { get; set; }
        #endregion
        
        protected override void ProcessRecord()
        {
            base.ProcessRecord();
            
            var resourceIdentifiersText = FormatParameterValuesForConfirmationMsg("FromEmailAddress", MyInvocation.BoundParameters);
            if (!ConfirmShouldProceed(this.Force.IsPresent, resourceIdentifiersText, "New-PINEDeliverabilityTestReport (CreateDeliverabilityTestReport)"))
            {
                return;
            }
            
            var context = new CmdletContext
            {
                Region = this.Region,
                Credentials = this.CurrentCredentials
            };
            
            // allow for manipulation of parameters prior to loading into context
            PreExecutionContextLoad(context);
            
            context.Content_Raw_Data = this.Raw_Data;
            context.Content_Simple_Body_Html_Charset = this.Html_Charset;
            context.Content_Simple_Body_Html_Data = this.Html_Data;
            context.Content_Simple_Body_Text_Charset = this.Text_Charset;
            context.Content_Simple_Body_Text_Data = this.Text_Data;
            context.Content_Simple_Subject_Charset = this.Subject_Charset;
            context.Content_Simple_Subject_Data = this.Subject_Data;
            context.FromEmailAddress = this.FromEmailAddress;
            context.ReportName = this.ReportName;
            if (this.Tag != null)
            {
                context.Tags = new List<Amazon.PinpointEmail.Model.Tag>(this.Tag);
            }
            
            // allow further manipulation of loaded context prior to processing
            PostExecutionContextLoad(context);
            
            var output = Execute(context) as CmdletOutput;
            ProcessOutput(output);
        }
        
        #region IExecutor Members
        
        public object Execute(ExecutorContext context)
        {
            System.IO.MemoryStream _Content_Raw_DataStream = null;
            
            try
            {
                var cmdletContext = context as CmdletContext;
                // create request
                var request = new Amazon.PinpointEmail.Model.CreateDeliverabilityTestReportRequest();
                
                
                 // populate Content
                bool requestContentIsNull = true;
                request.Content = new Amazon.PinpointEmail.Model.EmailContent();
                Amazon.PinpointEmail.Model.RawMessage requestContent_content_Raw = null;
                
                 // populate Raw
                bool requestContent_content_RawIsNull = true;
                requestContent_content_Raw = new Amazon.PinpointEmail.Model.RawMessage();
                System.IO.MemoryStream requestContent_content_Raw_raw_Data = null;
                if (cmdletContext.Content_Raw_Data != null)
                {
                    _Content_Raw_DataStream = new System.IO.MemoryStream(cmdletContext.Content_Raw_Data);
                    requestContent_content_Raw_raw_Data = _Content_Raw_DataStream;
                }
                if (requestContent_content_Raw_raw_Data != null)
                {
                    requestContent_content_Raw.Data = requestContent_content_Raw_raw_Data;
                    requestContent_content_RawIsNull = false;
                }
                 // determine if requestContent_content_Raw should be set to null
                if (requestContent_content_RawIsNull)
                {
                    requestContent_content_Raw = null;
                }
                if (requestContent_content_Raw != null)
                {
                    request.Content.Raw = requestContent_content_Raw;
                    requestContentIsNull = false;
                }
                Amazon.PinpointEmail.Model.Message requestContent_content_Simple = null;
                
                 // populate Simple
                bool requestContent_content_SimpleIsNull = true;
                requestContent_content_Simple = new Amazon.PinpointEmail.Model.Message();
                Amazon.PinpointEmail.Model.Body requestContent_content_Simple_content_Simple_Body = null;
                
                 // populate Body
                bool requestContent_content_Simple_content_Simple_BodyIsNull = true;
                requestContent_content_Simple_content_Simple_Body = new Amazon.PinpointEmail.Model.Body();
                Amazon.PinpointEmail.Model.Content requestContent_content_Simple_content_Simple_Body_content_Simple_Body_Html = null;
                
                 // populate Html
                bool requestContent_content_Simple_content_Simple_Body_content_Simple_Body_HtmlIsNull = true;
                requestContent_content_Simple_content_Simple_Body_content_Simple_Body_Html = new Amazon.PinpointEmail.Model.Content();
                System.String requestContent_content_Simple_content_Simple_Body_content_Simple_Body_Html_html_Charset = null;
                if (cmdletContext.Content_Simple_Body_Html_Charset != null)
                {
                    requestContent_content_Simple_content_Simple_Body_content_Simple_Body_Html_html_Charset = cmdletContext.Content_Simple_Body_Html_Charset;
                }
                if (requestContent_content_Simple_content_Simple_Body_content_Simple_Body_Html_html_Charset != null)
                {
                    requestContent_content_Simple_content_Simple_Body_content_Simple_Body_Html.Charset = requestContent_content_Simple_content_Simple_Body_content_Simple_Body_Html_html_Charset;
                    requestContent_content_Simple_content_Simple_Body_content_Simple_Body_HtmlIsNull = false;
                }
                System.String requestContent_content_Simple_content_Simple_Body_content_Simple_Body_Html_html_Data = null;
                if (cmdletContext.Content_Simple_Body_Html_Data != null)
                {
                    requestContent_content_Simple_content_Simple_Body_content_Simple_Body_Html_html_Data = cmdletContext.Content_Simple_Body_Html_Data;
                }
                if (requestContent_content_Simple_content_Simple_Body_content_Simple_Body_Html_html_Data != null)
                {
                    requestContent_content_Simple_content_Simple_Body_content_Simple_Body_Html.Data = requestContent_content_Simple_content_Simple_Body_content_Simple_Body_Html_html_Data;
                    requestContent_content_Simple_content_Simple_Body_content_Simple_Body_HtmlIsNull = false;
                }
                 // determine if requestContent_content_Simple_content_Simple_Body_content_Simple_Body_Html should be set to null
                if (requestContent_content_Simple_content_Simple_Body_content_Simple_Body_HtmlIsNull)
                {
                    requestContent_content_Simple_content_Simple_Body_content_Simple_Body_Html = null;
                }
                if (requestContent_content_Simple_content_Simple_Body_content_Simple_Body_Html != null)
                {
                    requestContent_content_Simple_content_Simple_Body.Html = requestContent_content_Simple_content_Simple_Body_content_Simple_Body_Html;
                    requestContent_content_Simple_content_Simple_BodyIsNull = false;
                }
                Amazon.PinpointEmail.Model.Content requestContent_content_Simple_content_Simple_Body_content_Simple_Body_Text = null;
                
                 // populate Text
                bool requestContent_content_Simple_content_Simple_Body_content_Simple_Body_TextIsNull = true;
                requestContent_content_Simple_content_Simple_Body_content_Simple_Body_Text = new Amazon.PinpointEmail.Model.Content();
                System.String requestContent_content_Simple_content_Simple_Body_content_Simple_Body_Text_text_Charset = null;
                if (cmdletContext.Content_Simple_Body_Text_Charset != null)
                {
                    requestContent_content_Simple_content_Simple_Body_content_Simple_Body_Text_text_Charset = cmdletContext.Content_Simple_Body_Text_Charset;
                }
                if (requestContent_content_Simple_content_Simple_Body_content_Simple_Body_Text_text_Charset != null)
                {
                    requestContent_content_Simple_content_Simple_Body_content_Simple_Body_Text.Charset = requestContent_content_Simple_content_Simple_Body_content_Simple_Body_Text_text_Charset;
                    requestContent_content_Simple_content_Simple_Body_content_Simple_Body_TextIsNull = false;
                }
                System.String requestContent_content_Simple_content_Simple_Body_content_Simple_Body_Text_text_Data = null;
                if (cmdletContext.Content_Simple_Body_Text_Data != null)
                {
                    requestContent_content_Simple_content_Simple_Body_content_Simple_Body_Text_text_Data = cmdletContext.Content_Simple_Body_Text_Data;
                }
                if (requestContent_content_Simple_content_Simple_Body_content_Simple_Body_Text_text_Data != null)
                {
                    requestContent_content_Simple_content_Simple_Body_content_Simple_Body_Text.Data = requestContent_content_Simple_content_Simple_Body_content_Simple_Body_Text_text_Data;
                    requestContent_content_Simple_content_Simple_Body_content_Simple_Body_TextIsNull = false;
                }
                 // determine if requestContent_content_Simple_content_Simple_Body_content_Simple_Body_Text should be set to null
                if (requestContent_content_Simple_content_Simple_Body_content_Simple_Body_TextIsNull)
                {
                    requestContent_content_Simple_content_Simple_Body_content_Simple_Body_Text = null;
                }
                if (requestContent_content_Simple_content_Simple_Body_content_Simple_Body_Text != null)
                {
                    requestContent_content_Simple_content_Simple_Body.Text = requestContent_content_Simple_content_Simple_Body_content_Simple_Body_Text;
                    requestContent_content_Simple_content_Simple_BodyIsNull = false;
                }
                 // determine if requestContent_content_Simple_content_Simple_Body should be set to null
                if (requestContent_content_Simple_content_Simple_BodyIsNull)
                {
                    requestContent_content_Simple_content_Simple_Body = null;
                }
                if (requestContent_content_Simple_content_Simple_Body != null)
                {
                    requestContent_content_Simple.Body = requestContent_content_Simple_content_Simple_Body;
                    requestContent_content_SimpleIsNull = false;
                }
                Amazon.PinpointEmail.Model.Content requestContent_content_Simple_content_Simple_Subject = null;
                
                 // populate Subject
                bool requestContent_content_Simple_content_Simple_SubjectIsNull = true;
                requestContent_content_Simple_content_Simple_Subject = new Amazon.PinpointEmail.Model.Content();
                System.String requestContent_content_Simple_content_Simple_Subject_subject_Charset = null;
                if (cmdletContext.Content_Simple_Subject_Charset != null)
                {
                    requestContent_content_Simple_content_Simple_Subject_subject_Charset = cmdletContext.Content_Simple_Subject_Charset;
                }
                if (requestContent_content_Simple_content_Simple_Subject_subject_Charset != null)
                {
                    requestContent_content_Simple_content_Simple_Subject.Charset = requestContent_content_Simple_content_Simple_Subject_subject_Charset;
                    requestContent_content_Simple_content_Simple_SubjectIsNull = false;
                }
                System.String requestContent_content_Simple_content_Simple_Subject_subject_Data = null;
                if (cmdletContext.Content_Simple_Subject_Data != null)
                {
                    requestContent_content_Simple_content_Simple_Subject_subject_Data = cmdletContext.Content_Simple_Subject_Data;
                }
                if (requestContent_content_Simple_content_Simple_Subject_subject_Data != null)
                {
                    requestContent_content_Simple_content_Simple_Subject.Data = requestContent_content_Simple_content_Simple_Subject_subject_Data;
                    requestContent_content_Simple_content_Simple_SubjectIsNull = false;
                }
                 // determine if requestContent_content_Simple_content_Simple_Subject should be set to null
                if (requestContent_content_Simple_content_Simple_SubjectIsNull)
                {
                    requestContent_content_Simple_content_Simple_Subject = null;
                }
                if (requestContent_content_Simple_content_Simple_Subject != null)
                {
                    requestContent_content_Simple.Subject = requestContent_content_Simple_content_Simple_Subject;
                    requestContent_content_SimpleIsNull = false;
                }
                 // determine if requestContent_content_Simple should be set to null
                if (requestContent_content_SimpleIsNull)
                {
                    requestContent_content_Simple = null;
                }
                if (requestContent_content_Simple != null)
                {
                    request.Content.Simple = requestContent_content_Simple;
                    requestContentIsNull = false;
                }
                 // determine if request.Content should be set to null
                if (requestContentIsNull)
                {
                    request.Content = null;
                }
                if (cmdletContext.FromEmailAddress != null)
                {
                    request.FromEmailAddress = cmdletContext.FromEmailAddress;
                }
                if (cmdletContext.ReportName != null)
                {
                    request.ReportName = cmdletContext.ReportName;
                }
                if (cmdletContext.Tags != null)
                {
                    request.Tags = cmdletContext.Tags;
                }
                
                CmdletOutput output;
                
                // issue call
                var client = Client ?? CreateClient(context.Credentials, context.Region);
                try
                {
                    var response = CallAWSServiceOperation(client, request);
                    Dictionary<string, object> notes = null;
                    object pipelineOutput = response;
                    output = new CmdletOutput
                    {
                        PipelineOutput = pipelineOutput,
                        ServiceResponse = response,
                        Notes = notes
                    };
                }
                catch (Exception e)
                {
                    output = new CmdletOutput { ErrorResponse = e };
                }
                
                return output;
            }
            finally
            {
                if( _Content_Raw_DataStream != null)
                {
                    _Content_Raw_DataStream.Dispose();
                }
            }
        }
        
        public ExecutorContext CreateContext()
        {
            return new CmdletContext();
        }
        
        #endregion
        
        #region AWS Service Operation Call
        
        private Amazon.PinpointEmail.Model.CreateDeliverabilityTestReportResponse CallAWSServiceOperation(IAmazonPinpointEmail client, Amazon.PinpointEmail.Model.CreateDeliverabilityTestReportRequest request)
        {
            Utils.Common.WriteVerboseEndpointMessage(this, client.Config, "Amazon Pinpoint Email", "CreateDeliverabilityTestReport");
            try
            {
                #if DESKTOP
                return client.CreateDeliverabilityTestReport(request);
                #elif CORECLR
                return client.CreateDeliverabilityTestReportAsync(request).GetAwaiter().GetResult();
                #else
                        #error "Unknown build edition"
                #endif
            }
            catch (AmazonServiceException exc)
            {
                var webException = exc.InnerException as System.Net.WebException;
                if (webException != null)
                {
                    throw new Exception(Utils.Common.FormatNameResolutionFailureMessage(client.Config, webException.Message), webException);
                }
                throw;
            }
        }
        
        #endregion
        
        internal partial class CmdletContext : ExecutorContext
        {
            public byte[] Content_Raw_Data { get; set; }
            public System.String Content_Simple_Body_Html_Charset { get; set; }
            public System.String Content_Simple_Body_Html_Data { get; set; }
            public System.String Content_Simple_Body_Text_Charset { get; set; }
            public System.String Content_Simple_Body_Text_Data { get; set; }
            public System.String Content_Simple_Subject_Charset { get; set; }
            public System.String Content_Simple_Subject_Data { get; set; }
            public System.String FromEmailAddress { get; set; }
            public System.String ReportName { get; set; }
            public List<Amazon.PinpointEmail.Model.Tag> Tags { get; set; }
        }
        
    }
}
