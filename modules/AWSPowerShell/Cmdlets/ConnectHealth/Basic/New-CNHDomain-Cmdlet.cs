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
using Amazon.ConnectHealth;
using Amazon.ConnectHealth.Model;

#pragma warning disable CS0618, CS0612
namespace Amazon.PowerShell.Cmdlets.CNH
{
    /// <summary>
    /// Creates a new Domain for managing HealthAgent resources.
    /// </summary>
    [Cmdlet("New", "CNHDomain", SupportsShouldProcess = true, ConfirmImpact = ConfirmImpact.Medium)]
    [OutputType("Amazon.ConnectHealth.Model.CreateDomainResponse")]
    [AWSCmdlet("Calls the Connect Health CreateDomain API operation.", Operation = new[] {"CreateDomain"}, SelectReturnType = typeof(Amazon.ConnectHealth.Model.CreateDomainResponse))]
    [AWSCmdletOutput("Amazon.ConnectHealth.Model.CreateDomainResponse",
        "This cmdlet returns an Amazon.ConnectHealth.Model.CreateDomainResponse object containing multiple properties."
    )]
    public partial class NewCNHDomainCmdlet : AmazonConnectHealthClientCmdlet, IExecutor
    {
        
        protected override bool IsGeneratedCmdlet { get; set; } = true;
        private readonly CancellationTokenSource _cancellationTokenSource = new CancellationTokenSource();
        
        #region Parameter WebAppSetupConfiguration_EhrRole
        /// <summary>
        /// <para>
        /// <para>ARN of the IAM role used for EHR operations.</para>
        /// </para>
        /// </summary>
        [System.Management.Automation.Parameter(ValueFromPipelineByPropertyName = true)]
        public System.String WebAppSetupConfiguration_EhrRole { get; set; }
        #endregion
        
        #region Parameter WebAppSetupConfiguration_IdcInstanceId
        /// <summary>
        /// <para>
        /// <para>The Identity Center instance ID to use for creating the application.</para>
        /// </para>
        /// </summary>
        [System.Management.Automation.Parameter(ValueFromPipelineByPropertyName = true)]
        public System.String WebAppSetupConfiguration_IdcInstanceId { get; set; }
        #endregion
        
        #region Parameter WebAppSetupConfiguration_IdcRegion
        /// <summary>
        /// <para>
        /// <para>The AWS region where Identity Center is configured.</para>
        /// </para>
        /// </summary>
        [System.Management.Automation.Parameter(ValueFromPipelineByPropertyName = true)]
        public System.String WebAppSetupConfiguration_IdcRegion { get; set; }
        #endregion
        
        #region Parameter KmsKeyArn
        /// <summary>
        /// <para>
        /// <para>The ARN of the KMS key to use for encrypting data in this Domain.</para>
        /// </para>
        /// </summary>
        [System.Management.Automation.Parameter(ValueFromPipelineByPropertyName = true)]
        public System.String KmsKeyArn { get; set; }
        #endregion
        
        #region Parameter Name
        /// <summary>
        /// <para>
        /// <para>The name for the new Domain.</para>
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
        
        #region Parameter Tag
        /// <summary>
        /// <para>
        /// <para>Tags to associate with the Domain.</para><para />
        /// Starting with version 4 of the SDK this property will default to null. If no data for this property is returned
        /// from the service the property will also be null. This was changed to improve performance and allow the SDK and caller
        /// to distinguish between a property not set or a property being empty to clear out a value. To retain the previous
        /// SDK behavior set the AWSConfigs.InitializeCollections static property to true.
        /// </para>
        /// </summary>
        [System.Management.Automation.Parameter(ValueFromPipelineByPropertyName = true)]
        [Alias("Tags")]
        public System.Collections.Hashtable Tag { get; set; }
        #endregion
        
        #region Parameter Select
        /// <summary>
        /// Use the -Select parameter to control the cmdlet output. The default value is '*'.
        /// Specifying -Select '*' will result in the cmdlet returning the whole service response (Amazon.ConnectHealth.Model.CreateDomainResponse).
        /// Specifying the name of a property of type Amazon.ConnectHealth.Model.CreateDomainResponse will result in that property being returned.
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
            if (!ConfirmShouldProceed(this.Force.IsPresent, resourceIdentifiersText, "New-CNHDomain (CreateDomain)"))
            {
                return;
            }
            
            var context = new CmdletContext();
            
            // allow for manipulation of parameters prior to loading into context
            PreExecutionContextLoad(context);
            
            if (ParameterWasBound(nameof(this.Select)))
            {
                context.Select = CreateSelectDelegate<Amazon.ConnectHealth.Model.CreateDomainResponse, NewCNHDomainCmdlet>(Select) ??
                    throw new System.ArgumentException("Invalid value for -Select parameter.", nameof(this.Select));
            }
            context.KmsKeyArn = this.KmsKeyArn;
            context.Name = this.Name;
            #if MODULAR
            if (this.Name == null && ParameterWasBound(nameof(this.Name)))
            {
                WriteWarning("You are passing $null as a value for parameter Name which is marked as required. In case you believe this parameter was incorrectly marked as required, report this by opening an issue at https://github.com/aws/aws-tools-for-powershell/issues.");
            }
            #endif
            if (this.Tag != null)
            {
                context.Tag = new Dictionary<System.String, System.String>(StringComparer.Ordinal);
                foreach (var hashKey in this.Tag.Keys)
                {
                    context.Tag.Add((String)hashKey, (System.String)(this.Tag[hashKey]));
                }
            }
            context.WebAppSetupConfiguration_EhrRole = this.WebAppSetupConfiguration_EhrRole;
            context.WebAppSetupConfiguration_IdcInstanceId = this.WebAppSetupConfiguration_IdcInstanceId;
            context.WebAppSetupConfiguration_IdcRegion = this.WebAppSetupConfiguration_IdcRegion;
            
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
            var request = new Amazon.ConnectHealth.Model.CreateDomainRequest();
            
            if (cmdletContext.KmsKeyArn != null)
            {
                request.KmsKeyArn = cmdletContext.KmsKeyArn;
            }
            if (cmdletContext.Name != null)
            {
                request.Name = cmdletContext.Name;
            }
            if (cmdletContext.Tag != null)
            {
                request.Tags = cmdletContext.Tag;
            }
            
             // populate WebAppSetupConfiguration
            var requestWebAppSetupConfigurationIsNull = true;
            request.WebAppSetupConfiguration = new Amazon.ConnectHealth.Model.CreateWebAppConfiguration();
            System.String requestWebAppSetupConfiguration_webAppSetupConfiguration_EhrRole = null;
            if (cmdletContext.WebAppSetupConfiguration_EhrRole != null)
            {
                requestWebAppSetupConfiguration_webAppSetupConfiguration_EhrRole = cmdletContext.WebAppSetupConfiguration_EhrRole;
            }
            if (requestWebAppSetupConfiguration_webAppSetupConfiguration_EhrRole != null)
            {
                request.WebAppSetupConfiguration.EhrRole = requestWebAppSetupConfiguration_webAppSetupConfiguration_EhrRole;
                requestWebAppSetupConfigurationIsNull = false;
            }
            System.String requestWebAppSetupConfiguration_webAppSetupConfiguration_IdcInstanceId = null;
            if (cmdletContext.WebAppSetupConfiguration_IdcInstanceId != null)
            {
                requestWebAppSetupConfiguration_webAppSetupConfiguration_IdcInstanceId = cmdletContext.WebAppSetupConfiguration_IdcInstanceId;
            }
            if (requestWebAppSetupConfiguration_webAppSetupConfiguration_IdcInstanceId != null)
            {
                request.WebAppSetupConfiguration.IdcInstanceId = requestWebAppSetupConfiguration_webAppSetupConfiguration_IdcInstanceId;
                requestWebAppSetupConfigurationIsNull = false;
            }
            System.String requestWebAppSetupConfiguration_webAppSetupConfiguration_IdcRegion = null;
            if (cmdletContext.WebAppSetupConfiguration_IdcRegion != null)
            {
                requestWebAppSetupConfiguration_webAppSetupConfiguration_IdcRegion = cmdletContext.WebAppSetupConfiguration_IdcRegion;
            }
            if (requestWebAppSetupConfiguration_webAppSetupConfiguration_IdcRegion != null)
            {
                request.WebAppSetupConfiguration.IdcRegion = requestWebAppSetupConfiguration_webAppSetupConfiguration_IdcRegion;
                requestWebAppSetupConfigurationIsNull = false;
            }
             // determine if request.WebAppSetupConfiguration should be set to null
            if (requestWebAppSetupConfigurationIsNull)
            {
                request.WebAppSetupConfiguration = null;
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
        
        private Amazon.ConnectHealth.Model.CreateDomainResponse CallAWSServiceOperation(IAmazonConnectHealth client, Amazon.ConnectHealth.Model.CreateDomainRequest request)
        {
            Utils.Common.WriteVerboseEndpointMessage(this, client.Config, "Connect Health", "CreateDomain");
            try
            {
                return client.CreateDomainAsync(request, _cancellationTokenSource.Token).GetAwaiter().GetResult();
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
            public System.String KmsKeyArn { get; set; }
            public System.String Name { get; set; }
            public Dictionary<System.String, System.String> Tag { get; set; }
            public System.String WebAppSetupConfiguration_EhrRole { get; set; }
            public System.String WebAppSetupConfiguration_IdcInstanceId { get; set; }
            public System.String WebAppSetupConfiguration_IdcRegion { get; set; }
            public System.Func<Amazon.ConnectHealth.Model.CreateDomainResponse, NewCNHDomainCmdlet, object> Select { get; set; } =
                (response, cmdlet) => response;
        }
        
    }
}
