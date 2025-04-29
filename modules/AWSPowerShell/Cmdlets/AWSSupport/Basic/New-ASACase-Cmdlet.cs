/*******************************************************************************
 *  Copyright Amazon.com, Inc. or its affiliates. All Rights Reserved.
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
using System.Threading;
using Amazon.AWSSupport;
using Amazon.AWSSupport.Model;

#pragma warning disable CS0618, CS0612
namespace Amazon.PowerShell.Cmdlets.ASA
{
    /// <summary>
    /// Creates a case in the Amazon Web Services Support Center. This operation is similar
    /// to how you create a case in the Amazon Web Services Support Center <a href="https://console.aws.amazon.com/support/home#/case/create">Create
    /// Case</a> page.
    /// 
    ///  
    /// <para>
    /// The Amazon Web Services Support API doesn't support requesting service limit increases.
    /// You can submit a service limit increase in the following ways: 
    /// </para><ul><li><para>
    /// Submit a request from the Amazon Web Services Support Center <a href="https://console.aws.amazon.com/support/home#/case/create">Create
    /// Case</a> page.
    /// </para></li><li><para>
    /// Use the Service Quotas <a href="https://docs.aws.amazon.com/servicequotas/2019-06-24/apireference/API_RequestServiceQuotaIncrease.html">RequestServiceQuotaIncrease</a>
    /// operation.
    /// </para></li></ul><para>
    /// A successful <c>CreateCase</c> request returns an Amazon Web Services Support case
    /// number. You can use the <a>DescribeCases</a> operation and specify the case number
    /// to get existing Amazon Web Services Support cases. After you create a case, use the
    /// <a>AddCommunicationToCase</a> operation to add additional communication or attachments
    /// to an existing case.
    /// </para><para>
    /// The <c>caseId</c> is separate from the <c>displayId</c> that appears in the <a href="https://console.aws.amazon.com/support">Amazon
    /// Web Services Support Center</a>. Use the <a>DescribeCases</a> operation to get the
    /// <c>displayId</c>.
    /// </para><note><ul><li><para>
    /// You must have a Business, Enterprise On-Ramp, or Enterprise Support plan to use the
    /// Amazon Web Services Support API. 
    /// </para></li><li><para>
    /// If you call the Amazon Web Services Support API from an account that doesn't have
    /// a Business, Enterprise On-Ramp, or Enterprise Support plan, the <c>SubscriptionRequiredException</c>
    /// error message appears. For information about changing your support plan, see <a href="http://aws.amazon.com/premiumsupport/">Amazon
    /// Web Services Support</a>.
    /// </para></li></ul></note>
    /// </summary>
    [Cmdlet("New", "ASACase", SupportsShouldProcess = true, ConfirmImpact = ConfirmImpact.Medium)]
    [OutputType("System.String")]
    [AWSCmdlet("Calls the AWS Support CreateCase API operation.", Operation = new[] {"CreateCase"}, SelectReturnType = typeof(Amazon.AWSSupport.Model.CreateCaseResponse))]
    [AWSCmdletOutput("System.String or Amazon.AWSSupport.Model.CreateCaseResponse",
        "This cmdlet returns a System.String object.",
        "The service call response (type Amazon.AWSSupport.Model.CreateCaseResponse) can be returned by specifying '-Select *'."
    )]
    public partial class NewASACaseCmdlet : AmazonAWSSupportClientCmdlet, IExecutor
    {
        
        protected override bool IsGeneratedCmdlet { get; set; } = true;
        private readonly CancellationTokenSource _cancellationTokenSource = new CancellationTokenSource();
        
        #region Parameter AttachmentSetId
        /// <summary>
        /// <para>
        /// <para>The ID of a set of one or more attachments for the case. Create the set by using the
        /// <a>AddAttachmentsToSet</a> operation.</para>
        /// </para>
        /// </summary>
        [System.Management.Automation.Parameter(ValueFromPipelineByPropertyName = true)]
        public System.String AttachmentSetId { get; set; }
        #endregion
        
        #region Parameter CategoryCode
        /// <summary>
        /// <para>
        /// <para>The category of problem for the support case. You also use the <a>DescribeServices</a>
        /// operation to get the category code for a service. Each Amazon Web Services service
        /// defines its own set of category codes.</para>
        /// </para>
        /// </summary>
        [System.Management.Automation.Parameter(Position = 3, ValueFromPipelineByPropertyName = true)]
        public System.String CategoryCode { get; set; }
        #endregion
        
        #region Parameter CcEmailAddress
        /// <summary>
        /// <para>
        /// <para>A list of email addresses that Amazon Web Services Support copies on case correspondence.
        /// Amazon Web Services Support identifies the account that creates the case when you
        /// specify your Amazon Web Services credentials in an HTTP POST method or use the <a href="http://aws.amazon.com/tools/">Amazon Web Services SDKs</a>. </para>
        /// </para>
        /// </summary>
        [System.Management.Automation.Parameter(ValueFromPipelineByPropertyName = true)]
        [Alias("CcEmailAddresses")]
        public System.String[] CcEmailAddress { get; set; }
        #endregion
        
        #region Parameter CommunicationBody
        /// <summary>
        /// <para>
        /// <para>The communication body text that describes the issue. This text appears in the <b>Description</b>
        /// field on the Amazon Web Services Support Center <a href="https://console.aws.amazon.com/support/home#/case/create">Create
        /// Case</a> page.</para>
        /// </para>
        /// </summary>
        #if !MODULAR
        [System.Management.Automation.Parameter(Position = 4, ValueFromPipelineByPropertyName = true)]
        #else
        [System.Management.Automation.Parameter(Position = 4, ValueFromPipelineByPropertyName = true, Mandatory = true)]
        [System.Management.Automation.AllowEmptyString]
        [System.Management.Automation.AllowNull]
        #endif
        [Amazon.PowerShell.Common.AWSRequiredParameter]
        public System.String CommunicationBody { get; set; }
        #endregion
        
        #region Parameter IssueType
        /// <summary>
        /// <para>
        /// <para>The type of issue for the case. You can specify <c>customer-service</c> or <c>technical</c>.
        /// If you don't specify a value, the default is <c>technical</c>.</para>
        /// </para>
        /// </summary>
        [System.Management.Automation.Parameter(ValueFromPipelineByPropertyName = true)]
        public System.String IssueType { get; set; }
        #endregion
        
        #region Parameter Language
        /// <summary>
        /// <para>
        /// <para>The language in which Amazon Web Services Support handles the case. Amazon Web Services
        /// Support currently supports Chinese (“zh”), English ("en"), Japanese ("ja") and Korean
        /// (“ko”). You must specify the ISO 639-1 code for the <c>language</c> parameter if you
        /// want support in that language.</para>
        /// </para>
        /// </summary>
        [System.Management.Automation.Parameter(ValueFromPipelineByPropertyName = true)]
        public System.String Language { get; set; }
        #endregion
        
        #region Parameter ServiceCode
        /// <summary>
        /// <para>
        /// <para>The code for the Amazon Web Services service. You can use the <a>DescribeServices</a>
        /// operation to get the possible <c>serviceCode</c> values.</para>
        /// </para>
        /// </summary>
        [System.Management.Automation.Parameter(Position = 1, ValueFromPipelineByPropertyName = true)]
        public System.String ServiceCode { get; set; }
        #endregion
        
        #region Parameter SeverityCode
        /// <summary>
        /// <para>
        /// <para>A value that indicates the urgency of the case. This value determines the response
        /// time according to your service level agreement with Amazon Web Services Support. You
        /// can use the <a>DescribeSeverityLevels</a> operation to get the possible values for
        /// <c>severityCode</c>. </para><para>For more information, see <a>SeverityLevel</a> and <a href="https://docs.aws.amazon.com/awssupport/latest/user/getting-started.html#choosing-severity">Choosing
        /// a Severity</a> in the <i>Amazon Web Services Support User Guide</i>.</para><note><para>The availability of severity levels depends on the support plan for the Amazon Web
        /// Services account.</para></note>
        /// </para>
        /// </summary>
        [System.Management.Automation.Parameter(Position = 2, ValueFromPipelineByPropertyName = true)]
        public System.String SeverityCode { get; set; }
        #endregion
        
        #region Parameter Subject
        /// <summary>
        /// <para>
        /// <para>The title of the support case. The title appears in the <b>Subject</b> field on the
        /// Amazon Web Services Support Center <a href="https://console.aws.amazon.com/support/home#/case/create">Create
        /// Case</a> page.</para>
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
        public System.String Subject { get; set; }
        #endregion
        
        #region Parameter Select
        /// <summary>
        /// Use the -Select parameter to control the cmdlet output. The default value is 'CaseId'.
        /// Specifying -Select '*' will result in the cmdlet returning the whole service response (Amazon.AWSSupport.Model.CreateCaseResponse).
        /// Specifying the name of a property of type Amazon.AWSSupport.Model.CreateCaseResponse will result in that property being returned.
        /// Specifying -Select '^ParameterName' will result in the cmdlet returning the selected cmdlet parameter value.
        /// </summary>
        [System.Management.Automation.Parameter(ValueFromPipelineByPropertyName = true)]
        public string Select { get; set; } = "CaseId";
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
        
        protected override void StopProcessing()
        {
            base.StopProcessing();
            _cancellationTokenSource.Cancel();
        }
        protected override void ProcessRecord()
        {
            base.ProcessRecord();
            
            var resourceIdentifiersText = FormatParameterValuesForConfirmationMsg(nameof(this.AttachmentSetId), MyInvocation.BoundParameters);
            if (!ConfirmShouldProceed(this.Force.IsPresent, resourceIdentifiersText, "New-ASACase (CreateCase)"))
            {
                return;
            }
            
            var context = new CmdletContext();
            
            // allow for manipulation of parameters prior to loading into context
            PreExecutionContextLoad(context);
            
            if (ParameterWasBound(nameof(this.Select)))
            {
                context.Select = CreateSelectDelegate<Amazon.AWSSupport.Model.CreateCaseResponse, NewASACaseCmdlet>(Select) ??
                    throw new System.ArgumentException("Invalid value for -Select parameter.", nameof(this.Select));
            }
            context.AttachmentSetId = this.AttachmentSetId;
            context.CategoryCode = this.CategoryCode;
            if (this.CcEmailAddress != null)
            {
                context.CcEmailAddress = new List<System.String>(this.CcEmailAddress);
            }
            context.CommunicationBody = this.CommunicationBody;
            #if MODULAR
            if (this.CommunicationBody == null && ParameterWasBound(nameof(this.CommunicationBody)))
            {
                WriteWarning("You are passing $null as a value for parameter CommunicationBody which is marked as required. In case you believe this parameter was incorrectly marked as required, report this by opening an issue at https://github.com/aws/aws-tools-for-powershell/issues.");
            }
            #endif
            context.IssueType = this.IssueType;
            context.Language = this.Language;
            context.ServiceCode = this.ServiceCode;
            context.SeverityCode = this.SeverityCode;
            context.Subject = this.Subject;
            #if MODULAR
            if (this.Subject == null && ParameterWasBound(nameof(this.Subject)))
            {
                WriteWarning("You are passing $null as a value for parameter Subject which is marked as required. In case you believe this parameter was incorrectly marked as required, report this by opening an issue at https://github.com/aws/aws-tools-for-powershell/issues.");
            }
            #endif
            
            // allow further manipulation of loaded context prior to processing
            PostExecutionContextLoad(context);
            
            var output = Execute(context) as CmdletOutput;
            ProcessOutput(output);
        }
        
        #region IExecutor Members
        
        public object Execute(ExecutorContext context)
        {
            var cmdletContext = context as CmdletContext;
            // create request
            var request = new Amazon.AWSSupport.Model.CreateCaseRequest();
            
            if (cmdletContext.AttachmentSetId != null)
            {
                request.AttachmentSetId = cmdletContext.AttachmentSetId;
            }
            if (cmdletContext.CategoryCode != null)
            {
                request.CategoryCode = cmdletContext.CategoryCode;
            }
            if (cmdletContext.CcEmailAddress != null)
            {
                request.CcEmailAddresses = cmdletContext.CcEmailAddress;
            }
            if (cmdletContext.CommunicationBody != null)
            {
                request.CommunicationBody = cmdletContext.CommunicationBody;
            }
            if (cmdletContext.IssueType != null)
            {
                request.IssueType = cmdletContext.IssueType;
            }
            if (cmdletContext.Language != null)
            {
                request.Language = cmdletContext.Language;
            }
            if (cmdletContext.ServiceCode != null)
            {
                request.ServiceCode = cmdletContext.ServiceCode;
            }
            if (cmdletContext.SeverityCode != null)
            {
                request.SeverityCode = cmdletContext.SeverityCode;
            }
            if (cmdletContext.Subject != null)
            {
                request.Subject = cmdletContext.Subject;
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
        
        public ExecutorContext CreateContext()
        {
            return new CmdletContext();
        }
        
        #endregion
        
        #region AWS Service Operation Call
        
        private Amazon.AWSSupport.Model.CreateCaseResponse CallAWSServiceOperation(IAmazonAWSSupport client, Amazon.AWSSupport.Model.CreateCaseRequest request)
        {
            Utils.Common.WriteVerboseEndpointMessage(this, client.Config, "AWS Support", "CreateCase");
            try
            {
                return client.CreateCaseAsync(request, _cancellationTokenSource.Token).GetAwaiter().GetResult();
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
            public System.String AttachmentSetId { get; set; }
            public System.String CategoryCode { get; set; }
            public List<System.String> CcEmailAddress { get; set; }
            public System.String CommunicationBody { get; set; }
            public System.String IssueType { get; set; }
            public System.String Language { get; set; }
            public System.String ServiceCode { get; set; }
            public System.String SeverityCode { get; set; }
            public System.String Subject { get; set; }
            public System.Func<Amazon.AWSSupport.Model.CreateCaseResponse, NewASACaseCmdlet, object> Select { get; set; } =
                (response, cmdlet) => response.CaseId;
        }
        
    }
}
