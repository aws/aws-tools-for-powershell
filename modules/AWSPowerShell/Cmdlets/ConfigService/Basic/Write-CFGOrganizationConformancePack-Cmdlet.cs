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
using Amazon.ConfigService;
using Amazon.ConfigService.Model;

namespace Amazon.PowerShell.Cmdlets.CFG
{
    /// <summary>
    /// Deploys conformance packs across member accounts in an Amazon Web Services Organization.
    /// For information on how many organization conformance packs and how many Config rules
    /// you can have per account, see <a href="https://docs.aws.amazon.com/config/latest/developerguide/configlimits.html"><b>Service Limits</b></a> in the <i>Config Developer Guide</i>.
    /// 
    ///  
    /// <para>
    /// Only a management account and a delegated administrator can call this API. When calling
    /// this API with a delegated administrator, you must ensure Organizations <c>ListDelegatedAdministrator</c>
    /// permissions are added. An organization can have up to 3 delegated administrators.
    /// </para><para>
    /// This API enables organization service access for <c>config-multiaccountsetup.amazonaws.com</c>
    /// through the <c>EnableAWSServiceAccess</c> action and creates a service-linked role
    /// <c>AWSServiceRoleForConfigMultiAccountSetup</c> in the management or delegated administrator
    /// account of your organization. The service-linked role is created only when the role
    /// does not exist in the caller account. To use this API with delegated administrator,
    /// register a delegated administrator by calling Amazon Web Services Organization <c>register-delegate-admin</c>
    /// for <c>config-multiaccountsetup.amazonaws.com</c>.
    /// </para><note><para>
    /// Prerequisite: Ensure you call <c>EnableAllFeatures</c> API to enable all features
    /// in an organization.
    /// </para><para>
    /// You must specify either the <c>TemplateS3Uri</c> or the <c>TemplateBody</c> parameter,
    /// but not both. If you provide both Config uses the <c>TemplateS3Uri</c> parameter and
    /// ignores the <c>TemplateBody</c> parameter.
    /// </para><para>
    /// Config sets the state of a conformance pack to CREATE_IN_PROGRESS and UPDATE_IN_PROGRESS
    /// until the conformance pack is created or updated. You cannot update a conformance
    /// pack while it is in this state.
    /// </para></note>
    /// </summary>
    [Cmdlet("Write", "CFGOrganizationConformancePack", SupportsShouldProcess = true, ConfirmImpact = ConfirmImpact.Medium)]
    [OutputType("System.String")]
    [AWSCmdlet("Calls the AWS Config PutOrganizationConformancePack API operation.", Operation = new[] {"PutOrganizationConformancePack"}, SelectReturnType = typeof(Amazon.ConfigService.Model.PutOrganizationConformancePackResponse))]
    [AWSCmdletOutput("System.String or Amazon.ConfigService.Model.PutOrganizationConformancePackResponse",
        "This cmdlet returns a System.String object.",
        "The service call response (type Amazon.ConfigService.Model.PutOrganizationConformancePackResponse) can be returned by specifying '-Select *'."
    )]
    public partial class WriteCFGOrganizationConformancePackCmdlet : AmazonConfigServiceClientCmdlet, IExecutor
    {
        
        protected override bool IsGeneratedCmdlet { get; set; } = true;
        private readonly CancellationTokenSource _cancellationTokenSource = new CancellationTokenSource();
        
        #region Parameter ConformancePackInputParameter
        /// <summary>
        /// <para>
        /// <para>A list of <c>ConformancePackInputParameter</c> objects.</para>
        /// </para>
        /// </summary>
        [System.Management.Automation.Parameter(ValueFromPipelineByPropertyName = true)]
        [Alias("ConformancePackInputParameters")]
        public Amazon.ConfigService.Model.ConformancePackInputParameter[] ConformancePackInputParameter { get; set; }
        #endregion
        
        #region Parameter DeliveryS3Bucket
        /// <summary>
        /// <para>
        /// <para>The name of the Amazon S3 bucket where Config stores conformance pack templates.</para><note><para>This field is optional. If used, it must be prefixed with <c>awsconfigconforms</c>.</para></note>
        /// </para>
        /// </summary>
        [System.Management.Automation.Parameter(ValueFromPipelineByPropertyName = true)]
        public System.String DeliveryS3Bucket { get; set; }
        #endregion
        
        #region Parameter DeliveryS3KeyPrefix
        /// <summary>
        /// <para>
        /// <para>The prefix for the Amazon S3 bucket.</para><note><para>This field is optional.</para></note>
        /// </para>
        /// </summary>
        [System.Management.Automation.Parameter(ValueFromPipelineByPropertyName = true)]
        public System.String DeliveryS3KeyPrefix { get; set; }
        #endregion
        
        #region Parameter ExcludedAccount
        /// <summary>
        /// <para>
        /// <para>A list of Amazon Web Services accounts to be excluded from an organization conformance
        /// pack while deploying a conformance pack.</para>
        /// </para>
        /// </summary>
        [System.Management.Automation.Parameter(ValueFromPipelineByPropertyName = true)]
        [Alias("ExcludedAccounts")]
        public System.String[] ExcludedAccount { get; set; }
        #endregion
        
        #region Parameter OrganizationConformancePackName
        /// <summary>
        /// <para>
        /// <para>Name of the organization conformance pack you want to create.</para>
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
        public System.String OrganizationConformancePackName { get; set; }
        #endregion
        
        #region Parameter TemplateBody
        /// <summary>
        /// <para>
        /// <para>A string containing full conformance pack template body. Structure containing the
        /// template body with a minimum length of 1 byte and a maximum length of 51,200 bytes.</para>
        /// </para>
        /// </summary>
        [System.Management.Automation.Parameter(ValueFromPipelineByPropertyName = true)]
        public System.String TemplateBody { get; set; }
        #endregion
        
        #region Parameter TemplateS3Uri
        /// <summary>
        /// <para>
        /// <para>Location of file containing the template body. The uri must point to the conformance
        /// pack template (max size: 300 KB).</para><note><para>You must have access to read Amazon S3 bucket. In addition, in order to ensure a successful
        /// deployment, the template object must not be in an <a href="https://docs.aws.amazon.com/AmazonS3/latest/userguide/storage-class-intro.html">archived
        /// storage class</a> if this parameter is passed.</para></note>
        /// </para>
        /// </summary>
        [System.Management.Automation.Parameter(ValueFromPipelineByPropertyName = true)]
        public System.String TemplateS3Uri { get; set; }
        #endregion
        
        #region Parameter Select
        /// <summary>
        /// Use the -Select parameter to control the cmdlet output. The default value is 'OrganizationConformancePackArn'.
        /// Specifying -Select '*' will result in the cmdlet returning the whole service response (Amazon.ConfigService.Model.PutOrganizationConformancePackResponse).
        /// Specifying the name of a property of type Amazon.ConfigService.Model.PutOrganizationConformancePackResponse will result in that property being returned.
        /// Specifying -Select '^ParameterName' will result in the cmdlet returning the selected cmdlet parameter value.
        /// </summary>
        [System.Management.Automation.Parameter(ValueFromPipelineByPropertyName = true)]
        public string Select { get; set; } = "OrganizationConformancePackArn";
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
            this._AWSSignerType = "v4";
            base.ProcessRecord();
            
            var resourceIdentifiersText = FormatParameterValuesForConfirmationMsg(nameof(this.OrganizationConformancePackName), MyInvocation.BoundParameters);
            if (!ConfirmShouldProceed(this.Force.IsPresent, resourceIdentifiersText, "Write-CFGOrganizationConformancePack (PutOrganizationConformancePack)"))
            {
                return;
            }
            
            var context = new CmdletContext();
            
            // allow for manipulation of parameters prior to loading into context
            PreExecutionContextLoad(context);
            
            if (ParameterWasBound(nameof(this.Select)))
            {
                context.Select = CreateSelectDelegate<Amazon.ConfigService.Model.PutOrganizationConformancePackResponse, WriteCFGOrganizationConformancePackCmdlet>(Select) ??
                    throw new System.ArgumentException("Invalid value for -Select parameter.", nameof(this.Select));
            }
            if (this.ConformancePackInputParameter != null)
            {
                context.ConformancePackInputParameter = new List<Amazon.ConfigService.Model.ConformancePackInputParameter>(this.ConformancePackInputParameter);
            }
            context.DeliveryS3Bucket = this.DeliveryS3Bucket;
            context.DeliveryS3KeyPrefix = this.DeliveryS3KeyPrefix;
            if (this.ExcludedAccount != null)
            {
                context.ExcludedAccount = new List<System.String>(this.ExcludedAccount);
            }
            context.OrganizationConformancePackName = this.OrganizationConformancePackName;
            #if MODULAR
            if (this.OrganizationConformancePackName == null && ParameterWasBound(nameof(this.OrganizationConformancePackName)))
            {
                WriteWarning("You are passing $null as a value for parameter OrganizationConformancePackName which is marked as required. In case you believe this parameter was incorrectly marked as required, report this by opening an issue at https://github.com/aws/aws-tools-for-powershell/issues.");
            }
            #endif
            context.TemplateBody = this.TemplateBody;
            context.TemplateS3Uri = this.TemplateS3Uri;
            
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
            var request = new Amazon.ConfigService.Model.PutOrganizationConformancePackRequest();
            
            if (cmdletContext.ConformancePackInputParameter != null)
            {
                request.ConformancePackInputParameters = cmdletContext.ConformancePackInputParameter;
            }
            if (cmdletContext.DeliveryS3Bucket != null)
            {
                request.DeliveryS3Bucket = cmdletContext.DeliveryS3Bucket;
            }
            if (cmdletContext.DeliveryS3KeyPrefix != null)
            {
                request.DeliveryS3KeyPrefix = cmdletContext.DeliveryS3KeyPrefix;
            }
            if (cmdletContext.ExcludedAccount != null)
            {
                request.ExcludedAccounts = cmdletContext.ExcludedAccount;
            }
            if (cmdletContext.OrganizationConformancePackName != null)
            {
                request.OrganizationConformancePackName = cmdletContext.OrganizationConformancePackName;
            }
            if (cmdletContext.TemplateBody != null)
            {
                request.TemplateBody = cmdletContext.TemplateBody;
            }
            if (cmdletContext.TemplateS3Uri != null)
            {
                request.TemplateS3Uri = cmdletContext.TemplateS3Uri;
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
        
        private Amazon.ConfigService.Model.PutOrganizationConformancePackResponse CallAWSServiceOperation(IAmazonConfigService client, Amazon.ConfigService.Model.PutOrganizationConformancePackRequest request)
        {
            Utils.Common.WriteVerboseEndpointMessage(this, client.Config, "AWS Config", "PutOrganizationConformancePack");
            try
            {
                return client.PutOrganizationConformancePackAsync(request, _cancellationTokenSource.Token).GetAwaiter().GetResult();
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
            public List<Amazon.ConfigService.Model.ConformancePackInputParameter> ConformancePackInputParameter { get; set; }
            public System.String DeliveryS3Bucket { get; set; }
            public System.String DeliveryS3KeyPrefix { get; set; }
            public List<System.String> ExcludedAccount { get; set; }
            public System.String OrganizationConformancePackName { get; set; }
            public System.String TemplateBody { get; set; }
            public System.String TemplateS3Uri { get; set; }
            public System.Func<Amazon.ConfigService.Model.PutOrganizationConformancePackResponse, WriteCFGOrganizationConformancePackCmdlet, object> Select { get; set; } =
                (response, cmdlet) => response.OrganizationConformancePackArn;
        }
        
    }
}
