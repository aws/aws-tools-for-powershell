/*******************************************************************************
 *  Copyright 2012-2019 Amazon.com, Inc. or its affiliates. All Rights Reserved.
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
    /// the <c>GetDeliverabilityTestReport</c> operation to view the results of the test.
    /// </summary>
    [Cmdlet("New", "PINEDeliverabilityTestReport", SupportsShouldProcess = true, ConfirmImpact = ConfirmImpact.Medium)]
    [OutputType("Amazon.PinpointEmail.Model.CreateDeliverabilityTestReportResponse")]
    [AWSCmdlet("Calls the Amazon Pinpoint Email CreateDeliverabilityTestReport API operation.", Operation = new[] {"CreateDeliverabilityTestReport"}, SelectReturnType = typeof(Amazon.PinpointEmail.Model.CreateDeliverabilityTestReportResponse))]
    [AWSCmdletOutput("Amazon.PinpointEmail.Model.CreateDeliverabilityTestReportResponse",
        "This cmdlet returns an Amazon.PinpointEmail.Model.CreateDeliverabilityTestReportResponse object containing multiple properties. The object can also be referenced from properties attached to the cmdlet entry in the $AWSHistory stack."
    )]
    public partial class NewPINEDeliverabilityTestReportCmdlet : AmazonPinpointEmailClientCmdlet, IExecutor
    {
        
        protected override bool IsGeneratedCmdlet { get; set; } = true;
        
        #region Parameter Html_Charset
        /// <summary>
        /// <para>
        /// <para>The character set for the content. Because of the constraints of the SMTP protocol,
        /// Amazon Pinpoint uses 7-bit ASCII by default. If the text includes characters outside
        /// of the ASCII range, you have to specify a character set. For example, you could specify
        /// <c>UTF-8</c>, <c>ISO-8859-1</c>, or <c>Shift_JIS</c>.</para>
        /// </para>
        /// </summary>
        [System.Management.Automation.Parameter(ValueFromPipelineByPropertyName = true)]
        [Alias("Content_Simple_Body_Html_Charset")]
        public System.String Html_Charset { get; set; }
        #endregion
        
        #region Parameter Text_Charset
        /// <summary>
        /// <para>
        /// <para>The character set for the content. Because of the constraints of the SMTP protocol,
        /// Amazon Pinpoint uses 7-bit ASCII by default. If the text includes characters outside
        /// of the ASCII range, you have to specify a character set. For example, you could specify
        /// <c>UTF-8</c>, <c>ISO-8859-1</c>, or <c>Shift_JIS</c>.</para>
        /// </para>
        /// </summary>
        [System.Management.Automation.Parameter(ValueFromPipelineByPropertyName = true)]
        [Alias("Content_Simple_Body_Text_Charset")]
        public System.String Text_Charset { get; set; }
        #endregion
        
        #region Parameter Subject_Charset
        /// <summary>
        /// <para>
        /// <para>The character set for the content. Because of the constraints of the SMTP protocol,
        /// Amazon Pinpoint uses 7-bit ASCII by default. If the text includes characters outside
        /// of the ASCII range, you have to specify a character set. For example, you could specify
        /// <c>UTF-8</c>, <c>ISO-8859-1</c>, or <c>Shift_JIS</c>.</para>
        /// </para>
        /// </summary>
        [System.Management.Automation.Parameter(ValueFromPipelineByPropertyName = true)]
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
        /// <para>The cmdlet will automatically convert the supplied parameter of type string, string[], System.IO.FileInfo or System.IO.Stream to byte[] before supplying it to the service.</para>
        /// </summary>
        [System.Management.Automation.Parameter(ValueFromPipelineByPropertyName = true)]
        [Alias("Content_Raw_Data")]
        [Amazon.PowerShell.Common.MemoryStreamParameterConverter]
        public byte[] Raw_Data { get; set; }
        #endregion
        
        #region Parameter Html_Data
        /// <summary>
        /// <para>
        /// <para>The content of the message itself.</para>
        /// </para>
        /// </summary>
        [System.Management.Automation.Parameter(ValueFromPipelineByPropertyName = true)]
        [Alias("Content_Simple_Body_Html_Data")]
        public System.String Html_Data { get; set; }
        #endregion
        
        #region Parameter Text_Data
        /// <summary>
        /// <para>
        /// <para>The content of the message itself.</para>
        /// </para>
        /// </summary>
        [System.Management.Automation.Parameter(ValueFromPipelineByPropertyName = true)]
        [Alias("Content_Simple_Body_Text_Data")]
        public System.String Text_Data { get; set; }
        #endregion
        
        #region Parameter Subject_Data
        /// <summary>
        /// <para>
        /// <para>The content of the message itself.</para>
        /// </para>
        /// </summary>
        [System.Management.Automation.Parameter(ValueFromPipelineByPropertyName = true)]
        [Alias("Content_Simple_Subject_Data")]
        public System.String Subject_Data { get; set; }
        #endregion
        
        #region Parameter FromEmailAddress
        /// <summary>
        /// <para>
        /// <para>The email address that the predictive inbox placement test email was sent from.</para>
        /// </para>
        /// </summary>
        #if !MODULAR
        [System.Management.Automation.Parameter(Position = 0, ValueFromPipelineByPropertyName = true, ValueFromPipeline = true)]
        #else
        [System.Management.Automation.Parameter(Position = 0, ValueFromPipelineByPropertyName = true, ValueFromPipeline = true, Mandatory = true)]
        [System.Management.Automation.AllowEmptyString]
        [System.Management.Automation.AllowNull]
        #endif
        [Amazon.PowerShell.Common.AWSRequiredParameter]
        public System.String FromEmailAddress { get; set; }
        #endregion
        
        #region Parameter ReportName
        /// <summary>
        /// <para>
        /// <para>A unique name that helps you to identify the predictive inbox placement test when
        /// you retrieve the results.</para>
        /// </para>
        /// </summary>
        [System.Management.Automation.Parameter(ValueFromPipelineByPropertyName = true)]
        public System.String ReportName { get; set; }
        #endregion
        
        #region Parameter Tag
        /// <summary>
        /// <para>
        /// <para>An array of objects that define the tags (keys and values) that you want to associate
        /// with the predictive inbox placement test.</para>
        /// </para>
        /// </summary>
        [System.Management.Automation.Parameter(ValueFromPipelineByPropertyName = true)]
        [Alias("Tags")]
        public Amazon.PinpointEmail.Model.Tag[] Tag { get; set; }
        #endregion
        
        #region Parameter Template_TemplateArn
        /// <summary>
        /// <para>
        /// <para>The Amazon Resource Name (ARN) of the template.</para>
        /// </para>
        /// </summary>
        [System.Management.Automation.Parameter(ValueFromPipelineByPropertyName = true)]
        [Alias("Content_Template_TemplateArn")]
        public System.String Template_TemplateArn { get; set; }
        #endregion
        
        #region Parameter Template_TemplateData
        /// <summary>
        /// <para>
        /// <para>An object that defines the values to use for message variables in the template. This
        /// object is a set of key-value pairs. Each key defines a message variable in the template.
        /// The corresponding value defines the value to use for that variable.</para>
        /// </para>
        /// </summary>
        [System.Management.Automation.Parameter(ValueFromPipelineByPropertyName = true)]
        [Alias("Content_Template_TemplateData")]
        public System.String Template_TemplateData { get; set; }
        #endregion
        
        #region Parameter Select
        /// <summary>
        /// Use the -Select parameter to control the cmdlet output. The default value is '*'.
        /// Specifying -Select '*' will result in the cmdlet returning the whole service response (Amazon.PinpointEmail.Model.CreateDeliverabilityTestReportResponse).
        /// Specifying the name of a property of type Amazon.PinpointEmail.Model.CreateDeliverabilityTestReportResponse will result in that property being returned.
        /// Specifying -Select '^ParameterName' will result in the cmdlet returning the selected cmdlet parameter value.
        /// </summary>
        [System.Management.Automation.Parameter(ValueFromPipelineByPropertyName = true)]
        public string Select { get; set; } = "*";
        #endregion
        
        #region Parameter PassThru
        /// <summary>
        /// Changes the cmdlet behavior to return the value passed to the FromEmailAddress parameter.
        /// The -PassThru parameter is deprecated, use -Select '^FromEmailAddress' instead. This parameter will be removed in a future version.
        /// </summary>
        [System.Obsolete("The -PassThru parameter is deprecated, use -Select '^FromEmailAddress' instead. This parameter will be removed in a future version.")]
        [System.Management.Automation.Parameter(ValueFromPipelineByPropertyName = true)]
        public SwitchParameter PassThru { get; set; }
        #endregion
        
        #region Parameter Force
        /// <summary>
        /// This parameter overrides confirmation prompts to force 
        /// the cmdlet to continue its operation. This parameter should always
        /// be used with caution.
        /// </summary>
        [System.Management.Automation.Parameter(ValueFromPipelineByPropertyName = true)]
        public SwitchParameter Force { get; set; }
        #endregion
        
        protected override void ProcessRecord()
        {
            this._AWSSignerType = "v4";
            base.ProcessRecord();
            
            var resourceIdentifiersText = FormatParameterValuesForConfirmationMsg(nameof(this.FromEmailAddress), MyInvocation.BoundParameters);
            if (!ConfirmShouldProceed(this.Force.IsPresent, resourceIdentifiersText, "New-PINEDeliverabilityTestReport (CreateDeliverabilityTestReport)"))
            {
                return;
            }
            
            var context = new CmdletContext();
            
            // allow for manipulation of parameters prior to loading into context
            PreExecutionContextLoad(context);
            
            #pragma warning disable CS0618, CS0612 //A class member was marked with the Obsolete attribute
            if (ParameterWasBound(nameof(this.Select)))
            {
                context.Select = CreateSelectDelegate<Amazon.PinpointEmail.Model.CreateDeliverabilityTestReportResponse, NewPINEDeliverabilityTestReportCmdlet>(Select) ??
                    throw new System.ArgumentException("Invalid value for -Select parameter.", nameof(this.Select));
                if (this.PassThru.IsPresent)
                {
                    throw new System.ArgumentException("-PassThru cannot be used when -Select is specified.", nameof(this.Select));
                }
            }
            else if (this.PassThru.IsPresent)
            {
                context.Select = (response, cmdlet) => this.FromEmailAddress;
            }
            #pragma warning restore CS0618, CS0612 //A class member was marked with the Obsolete attribute
            context.Raw_Data = this.Raw_Data;
            context.Html_Charset = this.Html_Charset;
            context.Html_Data = this.Html_Data;
            context.Text_Charset = this.Text_Charset;
            context.Text_Data = this.Text_Data;
            context.Subject_Charset = this.Subject_Charset;
            context.Subject_Data = this.Subject_Data;
            context.Template_TemplateArn = this.Template_TemplateArn;
            context.Template_TemplateData = this.Template_TemplateData;
            context.FromEmailAddress = this.FromEmailAddress;
            #if MODULAR
            if (this.FromEmailAddress == null && ParameterWasBound(nameof(this.FromEmailAddress)))
            {
                WriteWarning("You are passing $null as a value for parameter FromEmailAddress which is marked as required. In case you believe this parameter was incorrectly marked as required, report this by opening an issue at https://github.com/aws/aws-tools-for-powershell/issues.");
            }
            #endif
            context.ReportName = this.ReportName;
            if (this.Tag != null)
            {
                context.Tag = new List<Amazon.PinpointEmail.Model.Tag>(this.Tag);
            }
            
            // allow further manipulation of loaded context prior to processing
            PostExecutionContextLoad(context);
            
            var output = Execute(context) as CmdletOutput;
            ProcessOutput(output);
        }
        
        #region IExecutor Members
        
        public object Execute(ExecutorContext context)
        {
            System.IO.MemoryStream _Raw_DataStream = null;
            
            try
            {
                var cmdletContext = context as CmdletContext;
                // create request
                var request = new Amazon.PinpointEmail.Model.CreateDeliverabilityTestReportRequest();
                
                
                 // populate Content
                var requestContentIsNull = true;
                request.Content = new Amazon.PinpointEmail.Model.EmailContent();
                Amazon.PinpointEmail.Model.RawMessage requestContent_content_Raw = null;
                
                 // populate Raw
                var requestContent_content_RawIsNull = true;
                requestContent_content_Raw = new Amazon.PinpointEmail.Model.RawMessage();
                System.IO.MemoryStream requestContent_content_Raw_raw_Data = null;
                if (cmdletContext.Raw_Data != null)
                {
                    _Raw_DataStream = new System.IO.MemoryStream(cmdletContext.Raw_Data);
                    requestContent_content_Raw_raw_Data = _Raw_DataStream;
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
                var requestContent_content_SimpleIsNull = true;
                requestContent_content_Simple = new Amazon.PinpointEmail.Model.Message();
                Amazon.PinpointEmail.Model.Body requestContent_content_Simple_content_Simple_Body = null;
                
                 // populate Body
                var requestContent_content_Simple_content_Simple_BodyIsNull = true;
                requestContent_content_Simple_content_Simple_Body = new Amazon.PinpointEmail.Model.Body();
                Amazon.PinpointEmail.Model.Content requestContent_content_Simple_content_Simple_Body_content_Simple_Body_Html = null;
                
                 // populate Html
                var requestContent_content_Simple_content_Simple_Body_content_Simple_Body_HtmlIsNull = true;
                requestContent_content_Simple_content_Simple_Body_content_Simple_Body_Html = new Amazon.PinpointEmail.Model.Content();
                System.String requestContent_content_Simple_content_Simple_Body_content_Simple_Body_Html_html_Charset = null;
                if (cmdletContext.Html_Charset != null)
                {
                    requestContent_content_Simple_content_Simple_Body_content_Simple_Body_Html_html_Charset = cmdletContext.Html_Charset;
                }
                if (requestContent_content_Simple_content_Simple_Body_content_Simple_Body_Html_html_Charset != null)
                {
                    requestContent_content_Simple_content_Simple_Body_content_Simple_Body_Html.Charset = requestContent_content_Simple_content_Simple_Body_content_Simple_Body_Html_html_Charset;
                    requestContent_content_Simple_content_Simple_Body_content_Simple_Body_HtmlIsNull = false;
                }
                System.String requestContent_content_Simple_content_Simple_Body_content_Simple_Body_Html_html_Data = null;
                if (cmdletContext.Html_Data != null)
                {
                    requestContent_content_Simple_content_Simple_Body_content_Simple_Body_Html_html_Data = cmdletContext.Html_Data;
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
                var requestContent_content_Simple_content_Simple_Body_content_Simple_Body_TextIsNull = true;
                requestContent_content_Simple_content_Simple_Body_content_Simple_Body_Text = new Amazon.PinpointEmail.Model.Content();
                System.String requestContent_content_Simple_content_Simple_Body_content_Simple_Body_Text_text_Charset = null;
                if (cmdletContext.Text_Charset != null)
                {
                    requestContent_content_Simple_content_Simple_Body_content_Simple_Body_Text_text_Charset = cmdletContext.Text_Charset;
                }
                if (requestContent_content_Simple_content_Simple_Body_content_Simple_Body_Text_text_Charset != null)
                {
                    requestContent_content_Simple_content_Simple_Body_content_Simple_Body_Text.Charset = requestContent_content_Simple_content_Simple_Body_content_Simple_Body_Text_text_Charset;
                    requestContent_content_Simple_content_Simple_Body_content_Simple_Body_TextIsNull = false;
                }
                System.String requestContent_content_Simple_content_Simple_Body_content_Simple_Body_Text_text_Data = null;
                if (cmdletContext.Text_Data != null)
                {
                    requestContent_content_Simple_content_Simple_Body_content_Simple_Body_Text_text_Data = cmdletContext.Text_Data;
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
                var requestContent_content_Simple_content_Simple_SubjectIsNull = true;
                requestContent_content_Simple_content_Simple_Subject = new Amazon.PinpointEmail.Model.Content();
                System.String requestContent_content_Simple_content_Simple_Subject_subject_Charset = null;
                if (cmdletContext.Subject_Charset != null)
                {
                    requestContent_content_Simple_content_Simple_Subject_subject_Charset = cmdletContext.Subject_Charset;
                }
                if (requestContent_content_Simple_content_Simple_Subject_subject_Charset != null)
                {
                    requestContent_content_Simple_content_Simple_Subject.Charset = requestContent_content_Simple_content_Simple_Subject_subject_Charset;
                    requestContent_content_Simple_content_Simple_SubjectIsNull = false;
                }
                System.String requestContent_content_Simple_content_Simple_Subject_subject_Data = null;
                if (cmdletContext.Subject_Data != null)
                {
                    requestContent_content_Simple_content_Simple_Subject_subject_Data = cmdletContext.Subject_Data;
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
                Amazon.PinpointEmail.Model.Template requestContent_content_Template = null;
                
                 // populate Template
                var requestContent_content_TemplateIsNull = true;
                requestContent_content_Template = new Amazon.PinpointEmail.Model.Template();
                System.String requestContent_content_Template_template_TemplateArn = null;
                if (cmdletContext.Template_TemplateArn != null)
                {
                    requestContent_content_Template_template_TemplateArn = cmdletContext.Template_TemplateArn;
                }
                if (requestContent_content_Template_template_TemplateArn != null)
                {
                    requestContent_content_Template.TemplateArn = requestContent_content_Template_template_TemplateArn;
                    requestContent_content_TemplateIsNull = false;
                }
                System.String requestContent_content_Template_template_TemplateData = null;
                if (cmdletContext.Template_TemplateData != null)
                {
                    requestContent_content_Template_template_TemplateData = cmdletContext.Template_TemplateData;
                }
                if (requestContent_content_Template_template_TemplateData != null)
                {
                    requestContent_content_Template.TemplateData = requestContent_content_Template_template_TemplateData;
                    requestContent_content_TemplateIsNull = false;
                }
                 // determine if requestContent_content_Template should be set to null
                if (requestContent_content_TemplateIsNull)
                {
                    requestContent_content_Template = null;
                }
                if (requestContent_content_Template != null)
                {
                    request.Content.Template = requestContent_content_Template;
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
                if (cmdletContext.Tag != null)
                {
                    request.Tags = cmdletContext.Tag;
                }
                
                CmdletOutput output;
                
                // issue call
                var client = Client ?? CreateClient(_CurrentCredentials, _RegionEndpoint);
                try
                {
                    var response = CallAWSServiceOperation(client, request);
                    object pipelineOutput = null;
                    pipelineOutput = cmdletContext.Select(response, this);
                    output = new CmdletOutput
                    {
                        PipelineOutput = pipelineOutput,
                        ServiceResponse = response
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
                if( _Raw_DataStream != null)
                {
                    _Raw_DataStream.Dispose();
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
            public byte[] Raw_Data { get; set; }
            public System.String Html_Charset { get; set; }
            public System.String Html_Data { get; set; }
            public System.String Text_Charset { get; set; }
            public System.String Text_Data { get; set; }
            public System.String Subject_Charset { get; set; }
            public System.String Subject_Data { get; set; }
            public System.String Template_TemplateArn { get; set; }
            public System.String Template_TemplateData { get; set; }
            public System.String FromEmailAddress { get; set; }
            public System.String ReportName { get; set; }
            public List<Amazon.PinpointEmail.Model.Tag> Tag { get; set; }
            public System.Func<Amazon.PinpointEmail.Model.CreateDeliverabilityTestReportResponse, NewPINEDeliverabilityTestReportCmdlet, object> Select { get; set; } =
                (response, cmdlet) => response;
        }
        
    }
}
