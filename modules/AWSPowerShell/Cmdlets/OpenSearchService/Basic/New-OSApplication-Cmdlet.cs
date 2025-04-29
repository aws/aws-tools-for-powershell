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
using Amazon.OpenSearchService;
using Amazon.OpenSearchService.Model;

#pragma warning disable CS0618, CS0612
namespace Amazon.PowerShell.Cmdlets.OS
{
    /// <summary>
    /// Creates an OpenSearch UI application. For more information, see <a href="https://docs.aws.amazon.com/opensearch-service/latest/developerguide/application.html">Using
    /// the OpenSearch user interface in Amazon OpenSearch Service</a>.
    /// </summary>
    [Cmdlet("New", "OSApplication", SupportsShouldProcess = true, ConfirmImpact = ConfirmImpact.Medium)]
    [OutputType("Amazon.OpenSearchService.Model.CreateApplicationResponse")]
    [AWSCmdlet("Calls the Amazon OpenSearch Service CreateApplication API operation.", Operation = new[] {"CreateApplication"}, SelectReturnType = typeof(Amazon.OpenSearchService.Model.CreateApplicationResponse))]
    [AWSCmdletOutput("Amazon.OpenSearchService.Model.CreateApplicationResponse",
        "This cmdlet returns an Amazon.OpenSearchService.Model.CreateApplicationResponse object containing multiple properties."
    )]
    public partial class NewOSApplicationCmdlet : AmazonOpenSearchServiceClientCmdlet, IExecutor
    {
        
        protected override bool IsGeneratedCmdlet { get; set; } = true;
        private readonly CancellationTokenSource _cancellationTokenSource = new CancellationTokenSource();
        
        #region Parameter AppConfig
        /// <summary>
        /// <para>
        /// <para>Configuration settings for the OpenSearch application, including administrative options.</para>
        /// </para>
        /// </summary>
        [System.Management.Automation.Parameter(ValueFromPipelineByPropertyName = true)]
        [Alias("AppConfigs")]
        public Amazon.OpenSearchService.Model.AppConfig[] AppConfig { get; set; }
        #endregion
        
        #region Parameter DataSource
        /// <summary>
        /// <para>
        /// <para>The data sources to link to the OpenSearch application.</para>
        /// </para>
        /// </summary>
        [System.Management.Automation.Parameter(ValueFromPipelineByPropertyName = true)]
        [Alias("DataSources")]
        public Amazon.OpenSearchService.Model.DataSource[] DataSource { get; set; }
        #endregion
        
        #region Parameter IamIdentityCenterOptions_Enabled
        /// <summary>
        /// <para>
        /// <para>Specifies whether IAM Identity Center is enabled or disabled.</para>
        /// </para>
        /// </summary>
        [System.Management.Automation.Parameter(ValueFromPipelineByPropertyName = true)]
        public System.Boolean? IamIdentityCenterOptions_Enabled { get; set; }
        #endregion
        
        #region Parameter IamIdentityCenterOptions_IamIdentityCenterInstanceArn
        /// <summary>
        /// <para>
        /// The service has not provided documentation for this parameter; please refer to the service's API reference documentation for the latest available information.
        /// </para>
        /// </summary>
        [System.Management.Automation.Parameter(ValueFromPipelineByPropertyName = true)]
        public System.String IamIdentityCenterOptions_IamIdentityCenterInstanceArn { get; set; }
        #endregion
        
        #region Parameter IamIdentityCenterOptions_IamRoleForIdentityCenterApplicationArn
        /// <summary>
        /// <para>
        /// <para>The ARN of the IAM role associated with the IAM Identity Center application.</para>
        /// </para>
        /// </summary>
        [System.Management.Automation.Parameter(ValueFromPipelineByPropertyName = true)]
        public System.String IamIdentityCenterOptions_IamRoleForIdentityCenterApplicationArn { get; set; }
        #endregion
        
        #region Parameter Name
        /// <summary>
        /// <para>
        /// <para>The unique name of the OpenSearch application. Names must be unique within an Amazon
        /// Web Services Region for each account.</para>
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
        public System.String Name { get; set; }
        #endregion
        
        #region Parameter TagList
        /// <summary>
        /// <para>
        /// The service has not provided documentation for this parameter; please refer to the service's API reference documentation for the latest available information.
        /// </para>
        /// </summary>
        [System.Management.Automation.Parameter(ValueFromPipelineByPropertyName = true)]
        public Amazon.OpenSearchService.Model.Tag[] TagList { get; set; }
        #endregion
        
        #region Parameter ClientToken
        /// <summary>
        /// <para>
        /// <para>Unique, case-sensitive identifier to ensure idempotency of the request.</para>
        /// </para>
        /// </summary>
        [System.Management.Automation.Parameter(ValueFromPipelineByPropertyName = true)]
        public System.String ClientToken { get; set; }
        #endregion
        
        #region Parameter Select
        /// <summary>
        /// Use the -Select parameter to control the cmdlet output. The default value is '*'.
        /// Specifying -Select '*' will result in the cmdlet returning the whole service response (Amazon.OpenSearchService.Model.CreateApplicationResponse).
        /// Specifying the name of a property of type Amazon.OpenSearchService.Model.CreateApplicationResponse will result in that property being returned.
        /// Specifying -Select '^ParameterName' will result in the cmdlet returning the selected cmdlet parameter value.
        /// </summary>
        [System.Management.Automation.Parameter(ValueFromPipelineByPropertyName = true)]
        public string Select { get; set; } = "*";
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
            
            var resourceIdentifiersText = FormatParameterValuesForConfirmationMsg(nameof(this.Name), MyInvocation.BoundParameters);
            if (!ConfirmShouldProceed(this.Force.IsPresent, resourceIdentifiersText, "New-OSApplication (CreateApplication)"))
            {
                return;
            }
            
            var context = new CmdletContext();
            
            // allow for manipulation of parameters prior to loading into context
            PreExecutionContextLoad(context);
            
            if (ParameterWasBound(nameof(this.Select)))
            {
                context.Select = CreateSelectDelegate<Amazon.OpenSearchService.Model.CreateApplicationResponse, NewOSApplicationCmdlet>(Select) ??
                    throw new System.ArgumentException("Invalid value for -Select parameter.", nameof(this.Select));
            }
            if (this.AppConfig != null)
            {
                context.AppConfig = new List<Amazon.OpenSearchService.Model.AppConfig>(this.AppConfig);
            }
            context.ClientToken = this.ClientToken;
            if (this.DataSource != null)
            {
                context.DataSource = new List<Amazon.OpenSearchService.Model.DataSource>(this.DataSource);
            }
            context.IamIdentityCenterOptions_Enabled = this.IamIdentityCenterOptions_Enabled;
            context.IamIdentityCenterOptions_IamIdentityCenterInstanceArn = this.IamIdentityCenterOptions_IamIdentityCenterInstanceArn;
            context.IamIdentityCenterOptions_IamRoleForIdentityCenterApplicationArn = this.IamIdentityCenterOptions_IamRoleForIdentityCenterApplicationArn;
            context.Name = this.Name;
            #if MODULAR
            if (this.Name == null && ParameterWasBound(nameof(this.Name)))
            {
                WriteWarning("You are passing $null as a value for parameter Name which is marked as required. In case you believe this parameter was incorrectly marked as required, report this by opening an issue at https://github.com/aws/aws-tools-for-powershell/issues.");
            }
            #endif
            if (this.TagList != null)
            {
                context.TagList = new List<Amazon.OpenSearchService.Model.Tag>(this.TagList);
            }
            
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
            var request = new Amazon.OpenSearchService.Model.CreateApplicationRequest();
            
            if (cmdletContext.AppConfig != null)
            {
                request.AppConfigs = cmdletContext.AppConfig;
            }
            if (cmdletContext.ClientToken != null)
            {
                request.ClientToken = cmdletContext.ClientToken;
            }
            if (cmdletContext.DataSource != null)
            {
                request.DataSources = cmdletContext.DataSource;
            }
            
             // populate IamIdentityCenterOptions
            var requestIamIdentityCenterOptionsIsNull = true;
            request.IamIdentityCenterOptions = new Amazon.OpenSearchService.Model.IamIdentityCenterOptionsInput();
            System.Boolean? requestIamIdentityCenterOptions_iamIdentityCenterOptions_Enabled = null;
            if (cmdletContext.IamIdentityCenterOptions_Enabled != null)
            {
                requestIamIdentityCenterOptions_iamIdentityCenterOptions_Enabled = cmdletContext.IamIdentityCenterOptions_Enabled.Value;
            }
            if (requestIamIdentityCenterOptions_iamIdentityCenterOptions_Enabled != null)
            {
                request.IamIdentityCenterOptions.Enabled = requestIamIdentityCenterOptions_iamIdentityCenterOptions_Enabled.Value;
                requestIamIdentityCenterOptionsIsNull = false;
            }
            System.String requestIamIdentityCenterOptions_iamIdentityCenterOptions_IamIdentityCenterInstanceArn = null;
            if (cmdletContext.IamIdentityCenterOptions_IamIdentityCenterInstanceArn != null)
            {
                requestIamIdentityCenterOptions_iamIdentityCenterOptions_IamIdentityCenterInstanceArn = cmdletContext.IamIdentityCenterOptions_IamIdentityCenterInstanceArn;
            }
            if (requestIamIdentityCenterOptions_iamIdentityCenterOptions_IamIdentityCenterInstanceArn != null)
            {
                request.IamIdentityCenterOptions.IamIdentityCenterInstanceArn = requestIamIdentityCenterOptions_iamIdentityCenterOptions_IamIdentityCenterInstanceArn;
                requestIamIdentityCenterOptionsIsNull = false;
            }
            System.String requestIamIdentityCenterOptions_iamIdentityCenterOptions_IamRoleForIdentityCenterApplicationArn = null;
            if (cmdletContext.IamIdentityCenterOptions_IamRoleForIdentityCenterApplicationArn != null)
            {
                requestIamIdentityCenterOptions_iamIdentityCenterOptions_IamRoleForIdentityCenterApplicationArn = cmdletContext.IamIdentityCenterOptions_IamRoleForIdentityCenterApplicationArn;
            }
            if (requestIamIdentityCenterOptions_iamIdentityCenterOptions_IamRoleForIdentityCenterApplicationArn != null)
            {
                request.IamIdentityCenterOptions.IamRoleForIdentityCenterApplicationArn = requestIamIdentityCenterOptions_iamIdentityCenterOptions_IamRoleForIdentityCenterApplicationArn;
                requestIamIdentityCenterOptionsIsNull = false;
            }
             // determine if request.IamIdentityCenterOptions should be set to null
            if (requestIamIdentityCenterOptionsIsNull)
            {
                request.IamIdentityCenterOptions = null;
            }
            if (cmdletContext.Name != null)
            {
                request.Name = cmdletContext.Name;
            }
            if (cmdletContext.TagList != null)
            {
                request.TagList = cmdletContext.TagList;
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
        
        private Amazon.OpenSearchService.Model.CreateApplicationResponse CallAWSServiceOperation(IAmazonOpenSearchService client, Amazon.OpenSearchService.Model.CreateApplicationRequest request)
        {
            Utils.Common.WriteVerboseEndpointMessage(this, client.Config, "Amazon OpenSearch Service", "CreateApplication");
            try
            {
                return client.CreateApplicationAsync(request, _cancellationTokenSource.Token).GetAwaiter().GetResult();
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
            public List<Amazon.OpenSearchService.Model.AppConfig> AppConfig { get; set; }
            public System.String ClientToken { get; set; }
            public List<Amazon.OpenSearchService.Model.DataSource> DataSource { get; set; }
            public System.Boolean? IamIdentityCenterOptions_Enabled { get; set; }
            public System.String IamIdentityCenterOptions_IamIdentityCenterInstanceArn { get; set; }
            public System.String IamIdentityCenterOptions_IamRoleForIdentityCenterApplicationArn { get; set; }
            public System.String Name { get; set; }
            public List<Amazon.OpenSearchService.Model.Tag> TagList { get; set; }
            public System.Func<Amazon.OpenSearchService.Model.CreateApplicationResponse, NewOSApplicationCmdlet, object> Select { get; set; } =
                (response, cmdlet) => response;
        }
        
    }
}
