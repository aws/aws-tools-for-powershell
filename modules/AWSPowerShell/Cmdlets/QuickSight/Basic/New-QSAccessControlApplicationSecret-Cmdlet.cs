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
using Amazon.QuickSight;
using Amazon.QuickSight.Model;

#pragma warning disable CS0618, CS0612
namespace Amazon.PowerShell.Cmdlets.QS
{
    /// <summary>
    /// Creates a client secret for an access control application. An access control application
    /// can have up to two client secrets, so that you can rotate a secret without downtime.
    /// 
    ///  
    /// <para>
    /// Provide the Amazon Web Services Secrets Manager (Secrets Manager) secret ARN for each
    /// Region where the client secret, issued by your identity provider (IdP), is stored.
    /// </para>
    /// </summary>
    [Cmdlet("New", "QSAccessControlApplicationSecret", SupportsShouldProcess = true, ConfirmImpact = ConfirmImpact.Medium)]
    [OutputType("Amazon.QuickSight.Model.CreateAccessControlApplicationSecretResponse")]
    [AWSCmdlet("Calls the Amazon QuickSight CreateAccessControlApplicationSecret API operation.", Operation = new[] {"CreateAccessControlApplicationSecret"}, SelectReturnType = typeof(Amazon.QuickSight.Model.CreateAccessControlApplicationSecretResponse))]
    [AWSCmdletOutput("Amazon.QuickSight.Model.CreateAccessControlApplicationSecretResponse",
        "This cmdlet returns an Amazon.QuickSight.Model.CreateAccessControlApplicationSecretResponse object containing multiple properties."
    )]
    public partial class NewQSAccessControlApplicationSecretCmdlet : AmazonQuickSightClientCmdlet, IExecutor
    {
        
        protected override bool IsGeneratedCmdlet { get; set; } = true;
        private readonly CancellationTokenSource _cancellationTokenSource = new CancellationTokenSource();
        
        #region Parameter ApplicationId
        /// <summary>
        /// <para>
        /// <para>The ID of the access control application.</para>
        /// </para>
        /// </summary>
        #if !MODULAR
        [System.Management.Automation.Parameter(ValueFromPipelineByPropertyName = true)]
        #else
        [System.Management.Automation.Parameter(ValueFromPipelineByPropertyName = true, Mandatory = true)]
        [System.Management.Automation.AllowEmptyString]
        [System.Management.Automation.AllowNull]
        #endif
        [Amazon.PowerShell.Common.AWSRequiredParameter]
        public System.String ApplicationId { get; set; }
        #endregion
        
        #region Parameter AwsAccountId
        /// <summary>
        /// <para>
        /// <para>The ID of the Amazon Web Services account that contains the Quick Sight account.</para>
        /// </para>
        /// </summary>
        #if !MODULAR
        [System.Management.Automation.Parameter(ValueFromPipelineByPropertyName = true)]
        #else
        [System.Management.Automation.Parameter(ValueFromPipelineByPropertyName = true, Mandatory = true)]
        [System.Management.Automation.AllowEmptyString]
        [System.Management.Automation.AllowNull]
        #endif
        [Amazon.PowerShell.Common.AWSRequiredParameter]
        public System.String AwsAccountId { get; set; }
        #endregion
        
        #region Parameter ClientSecretConfiguration_ClientSecretSourceType
        /// <summary>
        /// <para>
        /// <para>The source of the client secret. The only valid value is <c>IDP_PROVIDED</c>: your
        /// IdP issued the secret value.</para>
        /// </para>
        /// </summary>
        #if !MODULAR
        [System.Management.Automation.Parameter(ValueFromPipelineByPropertyName = true)]
        #else
        [System.Management.Automation.Parameter(ValueFromPipelineByPropertyName = true, Mandatory = true)]
        [System.Management.Automation.AllowNull]
        #endif
        [Amazon.PowerShell.Common.AWSRequiredParameter]
        [AWSConstantClassSource("Amazon.QuickSight.ClientSecretSourceType")]
        public Amazon.QuickSight.ClientSecretSourceType ClientSecretConfiguration_ClientSecretSourceType { get; set; }
        #endregion
        
        #region Parameter Description
        /// <summary>
        /// <para>
        /// <para>A description of the client secret, for example <c>rotation-june-2026</c>. If you
        /// don't provide a description, the client secret has no description.</para>
        /// </para>
        /// </summary>
        [System.Management.Automation.Parameter(ValueFromPipelineByPropertyName = true)]
        public System.String Description { get; set; }
        #endregion
        
        #region Parameter ClientSecretConfiguration_ClientSecretConfigurationDetail_Idp_RegionalSecretManagerArn
        /// <summary>
        /// <para>
        /// <para>The ARN of the Amazon Web Services Secrets Manager secret that holds the client secret,
        /// for each Region.</para><para />
        /// Starting with version 4 of the SDK this property will default to null. If no data
        /// for this property is returned from the service the property will also be null. This
        /// was changed to improve performance and allow the SDK and caller to distinguish between
        /// a property not set or a property being empty to clear out a value. To retain the previous
        /// SDK behavior set the AWSConfigs.InitializeCollections static property to true.
        /// </para>
        /// </summary>
        [System.Management.Automation.Parameter(ValueFromPipelineByPropertyName = true)]
        [Alias("ClientSecretConfiguration_ClientSecretConfigurationDetail_Idp_RegionalSecretManagerArns")]
        public System.Collections.Hashtable ClientSecretConfiguration_ClientSecretConfigurationDetail_Idp_RegionalSecretManagerArn { get; set; }
        #endregion
        
        #region Parameter Select
        /// <summary>
        /// Use the -Select parameter to control the cmdlet output. The default value is '*'.
        /// Specifying -Select '*' will result in the cmdlet returning the whole service response (Amazon.QuickSight.Model.CreateAccessControlApplicationSecretResponse).
        /// Specifying the name of a property of type Amazon.QuickSight.Model.CreateAccessControlApplicationSecretResponse will result in that property being returned.
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
            
            var targetParameterNames = new string[]
            {
                nameof(this.ApplicationId),
                nameof(this.AwsAccountId)
            };
            var resourceIdentifiersText = FormatParameterValuesForConfirmationMsg(targetParameterNames, MyInvocation.BoundParameters);
            if (!ConfirmShouldProceed(this.Force.IsPresent, resourceIdentifiersText, "New-QSAccessControlApplicationSecret (CreateAccessControlApplicationSecret)"))
            {
                return;
            }
            
            var context = new CmdletContext();
            
            // allow for manipulation of parameters prior to loading into context
            PreExecutionContextLoad(context);
            
            if (ParameterWasBound(nameof(this.Select)))
            {
                context.Select = CreateSelectDelegate<Amazon.QuickSight.Model.CreateAccessControlApplicationSecretResponse, NewQSAccessControlApplicationSecretCmdlet>(Select) ??
                    throw new System.ArgumentException("Invalid value for -Select parameter.", nameof(this.Select));
            }
            context.ApplicationId = this.ApplicationId;
            #if MODULAR
            if (this.ApplicationId == null && ParameterWasBound(nameof(this.ApplicationId)))
            {
                WriteWarning("You are passing $null as a value for parameter ApplicationId which is marked as required. In case you believe this parameter was incorrectly marked as required, report this by opening an issue at https://github.com/aws/aws-tools-for-powershell/issues.");
            }
            #endif
            context.AwsAccountId = this.AwsAccountId;
            #if MODULAR
            if (this.AwsAccountId == null && ParameterWasBound(nameof(this.AwsAccountId)))
            {
                WriteWarning("You are passing $null as a value for parameter AwsAccountId which is marked as required. In case you believe this parameter was incorrectly marked as required, report this by opening an issue at https://github.com/aws/aws-tools-for-powershell/issues.");
            }
            #endif
            if (this.ClientSecretConfiguration_ClientSecretConfigurationDetail_Idp_RegionalSecretManagerArn != null)
            {
                context.ClientSecretConfiguration_ClientSecretConfigurationDetail_Idp_RegionalSecretManagerArn = new Dictionary<System.String, System.String>(StringComparer.Ordinal);
                foreach (var hashKey in this.ClientSecretConfiguration_ClientSecretConfigurationDetail_Idp_RegionalSecretManagerArn.Keys)
                {
                    context.ClientSecretConfiguration_ClientSecretConfigurationDetail_Idp_RegionalSecretManagerArn.Add((String)hashKey, (System.String)(this.ClientSecretConfiguration_ClientSecretConfigurationDetail_Idp_RegionalSecretManagerArn[hashKey]));
                }
            }
            context.ClientSecretConfiguration_ClientSecretSourceType = this.ClientSecretConfiguration_ClientSecretSourceType;
            #if MODULAR
            if (this.ClientSecretConfiguration_ClientSecretSourceType == null && ParameterWasBound(nameof(this.ClientSecretConfiguration_ClientSecretSourceType)))
            {
                WriteWarning("You are passing $null as a value for parameter ClientSecretConfiguration_ClientSecretSourceType which is marked as required. In case you believe this parameter was incorrectly marked as required, report this by opening an issue at https://github.com/aws/aws-tools-for-powershell/issues.");
            }
            #endif
            context.Description = this.Description;
            
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
            var request = new Amazon.QuickSight.Model.CreateAccessControlApplicationSecretRequest();
            
            if (cmdletContext.ApplicationId != null)
            {
                request.ApplicationId = cmdletContext.ApplicationId;
            }
            if (cmdletContext.AwsAccountId != null)
            {
                request.AwsAccountId = cmdletContext.AwsAccountId;
            }
            
             // populate ClientSecretConfiguration
            var requestClientSecretConfigurationIsNull = true;
            request.ClientSecretConfiguration = new Amazon.QuickSight.Model.ClientSecretConfiguration();
            Amazon.QuickSight.ClientSecretSourceType requestClientSecretConfiguration_clientSecretConfiguration_ClientSecretSourceType = null;
            if (cmdletContext.ClientSecretConfiguration_ClientSecretSourceType != null)
            {
                requestClientSecretConfiguration_clientSecretConfiguration_ClientSecretSourceType = cmdletContext.ClientSecretConfiguration_ClientSecretSourceType;
            }
            if (requestClientSecretConfiguration_clientSecretConfiguration_ClientSecretSourceType != null)
            {
                request.ClientSecretConfiguration.ClientSecretSourceType = requestClientSecretConfiguration_clientSecretConfiguration_ClientSecretSourceType;
                requestClientSecretConfigurationIsNull = false;
            }
            Amazon.QuickSight.Model.ClientSecretConfigurationDetail requestClientSecretConfiguration_clientSecretConfiguration_ClientSecretConfigurationDetail = null;
            
             // populate ClientSecretConfigurationDetail
            var requestClientSecretConfiguration_clientSecretConfiguration_ClientSecretConfigurationDetailIsNull = true;
            requestClientSecretConfiguration_clientSecretConfiguration_ClientSecretConfigurationDetail = new Amazon.QuickSight.Model.ClientSecretConfigurationDetail();
            Amazon.QuickSight.Model.IdpClientSecretInput requestClientSecretConfiguration_clientSecretConfiguration_ClientSecretConfigurationDetail_clientSecretConfiguration_ClientSecretConfigurationDetail_Idp = null;
            
             // populate Idp
            var requestClientSecretConfiguration_clientSecretConfiguration_ClientSecretConfigurationDetail_clientSecretConfiguration_ClientSecretConfigurationDetail_IdpIsNull = true;
            requestClientSecretConfiguration_clientSecretConfiguration_ClientSecretConfigurationDetail_clientSecretConfiguration_ClientSecretConfigurationDetail_Idp = new Amazon.QuickSight.Model.IdpClientSecretInput();
            Dictionary<System.String, System.String> requestClientSecretConfiguration_clientSecretConfiguration_ClientSecretConfigurationDetail_clientSecretConfiguration_ClientSecretConfigurationDetail_Idp_clientSecretConfiguration_ClientSecretConfigurationDetail_Idp_RegionalSecretManagerArn = null;
            if (cmdletContext.ClientSecretConfiguration_ClientSecretConfigurationDetail_Idp_RegionalSecretManagerArn != null)
            {
                requestClientSecretConfiguration_clientSecretConfiguration_ClientSecretConfigurationDetail_clientSecretConfiguration_ClientSecretConfigurationDetail_Idp_clientSecretConfiguration_ClientSecretConfigurationDetail_Idp_RegionalSecretManagerArn = cmdletContext.ClientSecretConfiguration_ClientSecretConfigurationDetail_Idp_RegionalSecretManagerArn;
            }
            if (requestClientSecretConfiguration_clientSecretConfiguration_ClientSecretConfigurationDetail_clientSecretConfiguration_ClientSecretConfigurationDetail_Idp_clientSecretConfiguration_ClientSecretConfigurationDetail_Idp_RegionalSecretManagerArn != null)
            {
                requestClientSecretConfiguration_clientSecretConfiguration_ClientSecretConfigurationDetail_clientSecretConfiguration_ClientSecretConfigurationDetail_Idp.RegionalSecretManagerArns = requestClientSecretConfiguration_clientSecretConfiguration_ClientSecretConfigurationDetail_clientSecretConfiguration_ClientSecretConfigurationDetail_Idp_clientSecretConfiguration_ClientSecretConfigurationDetail_Idp_RegionalSecretManagerArn;
                requestClientSecretConfiguration_clientSecretConfiguration_ClientSecretConfigurationDetail_clientSecretConfiguration_ClientSecretConfigurationDetail_IdpIsNull = false;
            }
             // determine if requestClientSecretConfiguration_clientSecretConfiguration_ClientSecretConfigurationDetail_clientSecretConfiguration_ClientSecretConfigurationDetail_Idp should be set to null
            if (requestClientSecretConfiguration_clientSecretConfiguration_ClientSecretConfigurationDetail_clientSecretConfiguration_ClientSecretConfigurationDetail_IdpIsNull)
            {
                requestClientSecretConfiguration_clientSecretConfiguration_ClientSecretConfigurationDetail_clientSecretConfiguration_ClientSecretConfigurationDetail_Idp = null;
            }
            if (requestClientSecretConfiguration_clientSecretConfiguration_ClientSecretConfigurationDetail_clientSecretConfiguration_ClientSecretConfigurationDetail_Idp != null)
            {
                requestClientSecretConfiguration_clientSecretConfiguration_ClientSecretConfigurationDetail.Idp = requestClientSecretConfiguration_clientSecretConfiguration_ClientSecretConfigurationDetail_clientSecretConfiguration_ClientSecretConfigurationDetail_Idp;
                requestClientSecretConfiguration_clientSecretConfiguration_ClientSecretConfigurationDetailIsNull = false;
            }
             // determine if requestClientSecretConfiguration_clientSecretConfiguration_ClientSecretConfigurationDetail should be set to null
            if (requestClientSecretConfiguration_clientSecretConfiguration_ClientSecretConfigurationDetailIsNull)
            {
                requestClientSecretConfiguration_clientSecretConfiguration_ClientSecretConfigurationDetail = null;
            }
            if (requestClientSecretConfiguration_clientSecretConfiguration_ClientSecretConfigurationDetail != null)
            {
                request.ClientSecretConfiguration.ClientSecretConfigurationDetail = requestClientSecretConfiguration_clientSecretConfiguration_ClientSecretConfigurationDetail;
                requestClientSecretConfigurationIsNull = false;
            }
             // determine if request.ClientSecretConfiguration should be set to null
            if (requestClientSecretConfigurationIsNull)
            {
                request.ClientSecretConfiguration = null;
            }
            if (cmdletContext.Description != null)
            {
                request.Description = cmdletContext.Description;
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
        
        private Amazon.QuickSight.Model.CreateAccessControlApplicationSecretResponse CallAWSServiceOperation(IAmazonQuickSight client, Amazon.QuickSight.Model.CreateAccessControlApplicationSecretRequest request)
        {
            Utils.Common.WriteVerboseEndpointMessage(this, client.Config, "Amazon QuickSight", "CreateAccessControlApplicationSecret");
            try
            {
                return client.CreateAccessControlApplicationSecretAsync(request, _cancellationTokenSource.Token).GetAwaiter().GetResult();
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
            public System.String ApplicationId { get; set; }
            public System.String AwsAccountId { get; set; }
            public Dictionary<System.String, System.String> ClientSecretConfiguration_ClientSecretConfigurationDetail_Idp_RegionalSecretManagerArn { get; set; }
            public Amazon.QuickSight.ClientSecretSourceType ClientSecretConfiguration_ClientSecretSourceType { get; set; }
            public System.String Description { get; set; }
            public System.Func<Amazon.QuickSight.Model.CreateAccessControlApplicationSecretResponse, NewQSAccessControlApplicationSecretCmdlet, object> Select { get; set; } =
                (response, cmdlet) => response;
        }
        
    }
}
