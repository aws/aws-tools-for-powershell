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
using Amazon.CloudDirectory;
using Amazon.CloudDirectory.Model;

namespace Amazon.PowerShell.Cmdlets.CDIR
{
    /// <summary>
    /// Upgrades a published schema under a new minor version revision using the current contents
    /// of <c>DevelopmentSchemaArn</c>.
    /// </summary>
    [Cmdlet("Update", "CDIRPublishedSchema", SupportsShouldProcess = true, ConfirmImpact = ConfirmImpact.Medium)]
    [OutputType("System.String")]
    [AWSCmdlet("Calls the Amazon Cloud Directory UpgradePublishedSchema API operation.", Operation = new[] {"UpgradePublishedSchema"}, SelectReturnType = typeof(Amazon.CloudDirectory.Model.UpgradePublishedSchemaResponse))]
    [AWSCmdletOutput("System.String or Amazon.CloudDirectory.Model.UpgradePublishedSchemaResponse",
        "This cmdlet returns a System.String object.",
        "The service call response (type Amazon.CloudDirectory.Model.UpgradePublishedSchemaResponse) can be returned by specifying '-Select *'."
    )]
    public partial class UpdateCDIRPublishedSchemaCmdlet : AmazonCloudDirectoryClientCmdlet, IExecutor
    {
        
        protected override bool IsGeneratedCmdlet { get; set; } = true;
        private readonly CancellationTokenSource _cancellationTokenSource = new CancellationTokenSource();
        
        #region Parameter DevelopmentSchemaArn
        /// <summary>
        /// <para>
        /// <para>The ARN of the development schema with the changes used for the upgrade.</para>
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
        public System.String DevelopmentSchemaArn { get; set; }
        #endregion
        
        #region Parameter DryRun
        /// <summary>
        /// <para>
        /// <para>Used for testing whether the Development schema provided is backwards compatible,
        /// or not, with the publish schema provided by the user to be upgraded. If schema compatibility
        /// fails, an exception would be thrown else the call would succeed. This parameter is
        /// optional and defaults to false.</para>
        /// </para>
        /// </summary>
        [System.Management.Automation.Parameter(ValueFromPipelineByPropertyName = true)]
        public System.Boolean? DryRun { get; set; }
        #endregion
        
        #region Parameter MinorVersion
        /// <summary>
        /// <para>
        /// <para>Identifies the minor version of the published schema that will be created. This parameter
        /// is NOT optional.</para>
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
        public System.String MinorVersion { get; set; }
        #endregion
        
        #region Parameter PublishedSchemaArn
        /// <summary>
        /// <para>
        /// <para>The ARN of the published schema to be upgraded.</para>
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
        public System.String PublishedSchemaArn { get; set; }
        #endregion
        
        #region Parameter Select
        /// <summary>
        /// Use the -Select parameter to control the cmdlet output. The default value is 'UpgradedSchemaArn'.
        /// Specifying -Select '*' will result in the cmdlet returning the whole service response (Amazon.CloudDirectory.Model.UpgradePublishedSchemaResponse).
        /// Specifying the name of a property of type Amazon.CloudDirectory.Model.UpgradePublishedSchemaResponse will result in that property being returned.
        /// Specifying -Select '^ParameterName' will result in the cmdlet returning the selected cmdlet parameter value.
        /// </summary>
        [System.Management.Automation.Parameter(ValueFromPipelineByPropertyName = true)]
        public string Select { get; set; } = "UpgradedSchemaArn";
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
            
            var resourceIdentifiersText = FormatParameterValuesForConfirmationMsg(nameof(this.DevelopmentSchemaArn), MyInvocation.BoundParameters);
            if (!ConfirmShouldProceed(this.Force.IsPresent, resourceIdentifiersText, "Update-CDIRPublishedSchema (UpgradePublishedSchema)"))
            {
                return;
            }
            
            var context = new CmdletContext();
            
            // allow for manipulation of parameters prior to loading into context
            PreExecutionContextLoad(context);
            
            if (ParameterWasBound(nameof(this.Select)))
            {
                context.Select = CreateSelectDelegate<Amazon.CloudDirectory.Model.UpgradePublishedSchemaResponse, UpdateCDIRPublishedSchemaCmdlet>(Select) ??
                    throw new System.ArgumentException("Invalid value for -Select parameter.", nameof(this.Select));
            }
            context.DevelopmentSchemaArn = this.DevelopmentSchemaArn;
            #if MODULAR
            if (this.DevelopmentSchemaArn == null && ParameterWasBound(nameof(this.DevelopmentSchemaArn)))
            {
                WriteWarning("You are passing $null as a value for parameter DevelopmentSchemaArn which is marked as required. In case you believe this parameter was incorrectly marked as required, report this by opening an issue at https://github.com/aws/aws-tools-for-powershell/issues.");
            }
            #endif
            context.DryRun = this.DryRun;
            context.MinorVersion = this.MinorVersion;
            #if MODULAR
            if (this.MinorVersion == null && ParameterWasBound(nameof(this.MinorVersion)))
            {
                WriteWarning("You are passing $null as a value for parameter MinorVersion which is marked as required. In case you believe this parameter was incorrectly marked as required, report this by opening an issue at https://github.com/aws/aws-tools-for-powershell/issues.");
            }
            #endif
            context.PublishedSchemaArn = this.PublishedSchemaArn;
            #if MODULAR
            if (this.PublishedSchemaArn == null && ParameterWasBound(nameof(this.PublishedSchemaArn)))
            {
                WriteWarning("You are passing $null as a value for parameter PublishedSchemaArn which is marked as required. In case you believe this parameter was incorrectly marked as required, report this by opening an issue at https://github.com/aws/aws-tools-for-powershell/issues.");
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
            var request = new Amazon.CloudDirectory.Model.UpgradePublishedSchemaRequest();
            
            if (cmdletContext.DevelopmentSchemaArn != null)
            {
                request.DevelopmentSchemaArn = cmdletContext.DevelopmentSchemaArn;
            }
            if (cmdletContext.DryRun != null)
            {
                request.DryRun = cmdletContext.DryRun.Value;
            }
            if (cmdletContext.MinorVersion != null)
            {
                request.MinorVersion = cmdletContext.MinorVersion;
            }
            if (cmdletContext.PublishedSchemaArn != null)
            {
                request.PublishedSchemaArn = cmdletContext.PublishedSchemaArn;
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
        
        private Amazon.CloudDirectory.Model.UpgradePublishedSchemaResponse CallAWSServiceOperation(IAmazonCloudDirectory client, Amazon.CloudDirectory.Model.UpgradePublishedSchemaRequest request)
        {
            Utils.Common.WriteVerboseEndpointMessage(this, client.Config, "Amazon Cloud Directory", "UpgradePublishedSchema");
            try
            {
                return client.UpgradePublishedSchemaAsync(request, _cancellationTokenSource.Token).GetAwaiter().GetResult();
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
            public System.String DevelopmentSchemaArn { get; set; }
            public System.Boolean? DryRun { get; set; }
            public System.String MinorVersion { get; set; }
            public System.String PublishedSchemaArn { get; set; }
            public System.Func<Amazon.CloudDirectory.Model.UpgradePublishedSchemaResponse, UpdateCDIRPublishedSchemaCmdlet, object> Select { get; set; } =
                (response, cmdlet) => response.UpgradedSchemaArn;
        }
        
    }
}
