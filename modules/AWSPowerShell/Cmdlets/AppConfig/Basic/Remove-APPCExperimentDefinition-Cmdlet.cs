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
using Amazon.AppConfig;
using Amazon.AppConfig.Model;

#pragma warning disable CS0618, CS0612
namespace Amazon.PowerShell.Cmdlets.APPC
{
    /// <summary>
    /// Deletes an experiment definition. You can archive the definition to hide it from the
    /// active list while preserving it for future reference, or permanently delete it along
    /// with all associated run history.
    /// </summary>
    [Cmdlet("Remove", "APPCExperimentDefinition", SupportsShouldProcess = true, ConfirmImpact = ConfirmImpact.High)]
    [OutputType("None")]
    [AWSCmdlet("Calls the AWS AppConfig DeleteExperimentDefinition API operation.", Operation = new[] {"DeleteExperimentDefinition"}, SelectReturnType = typeof(Amazon.AppConfig.Model.DeleteExperimentDefinitionResponse))]
    [AWSCmdletOutput("None or Amazon.AppConfig.Model.DeleteExperimentDefinitionResponse",
        "This cmdlet does not generate any output." +
        "The service response (type Amazon.AppConfig.Model.DeleteExperimentDefinitionResponse) be returned by specifying '-Select *'."
    )]
    public partial class RemoveAPPCExperimentDefinitionCmdlet : AmazonAppConfigClientCmdlet, IExecutor
    {
        
        protected override bool IsGeneratedCmdlet { get; set; } = true;
        private readonly CancellationTokenSource _cancellationTokenSource = new CancellationTokenSource();
        
        #region Parameter ApplicationIdentifier
        /// <summary>
        /// <para>
        /// <para>The application ID or name.</para>
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
        public System.String ApplicationIdentifier { get; set; }
        #endregion
        
        #region Parameter DeleteType
        /// <summary>
        /// <para>
        /// <para>The type of deletion to perform. Valid values include archive (hide but preserve)
        /// and permanent (delete permanently).</para>
        /// </para>
        /// </summary>
        [System.Management.Automation.Parameter(ValueFromPipelineByPropertyName = true)]
        [AWSConstantClassSource("Amazon.AppConfig.DeleteType")]
        public Amazon.AppConfig.DeleteType DeleteType { get; set; }
        #endregion
        
        #region Parameter ExperimentDefinitionIdentifier
        /// <summary>
        /// <para>
        /// <para>The experiment definition ID or name.</para>
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
        public System.String ExperimentDefinitionIdentifier { get; set; }
        #endregion
        
        #region Parameter Select
        /// <summary>
        /// Use the -Select parameter to control the cmdlet output. The cmdlet doesn't have a return value by default.
        /// Specifying -Select '*' will result in the cmdlet returning the whole service response (Amazon.AppConfig.Model.DeleteExperimentDefinitionResponse).
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
            
            var resourceIdentifiersText = FormatParameterValuesForConfirmationMsg(nameof(this.ExperimentDefinitionIdentifier), MyInvocation.BoundParameters);
            if (!ConfirmShouldProceed(this.Force.IsPresent, resourceIdentifiersText, "Remove-APPCExperimentDefinition (DeleteExperimentDefinition)"))
            {
                return;
            }
            
            var context = new CmdletContext();
            
            // allow for manipulation of parameters prior to loading into context
            PreExecutionContextLoad(context);
            
            if (ParameterWasBound(nameof(this.Select)))
            {
                context.Select = CreateSelectDelegate<Amazon.AppConfig.Model.DeleteExperimentDefinitionResponse, RemoveAPPCExperimentDefinitionCmdlet>(Select) ??
                    throw new System.ArgumentException("Invalid value for -Select parameter.", nameof(this.Select));
            }
            context.ApplicationIdentifier = this.ApplicationIdentifier;
            #if MODULAR
            if (this.ApplicationIdentifier == null && ParameterWasBound(nameof(this.ApplicationIdentifier)))
            {
                WriteWarning("You are passing $null as a value for parameter ApplicationIdentifier which is marked as required. In case you believe this parameter was incorrectly marked as required, report this by opening an issue at https://github.com/aws/aws-tools-for-powershell/issues.");
            }
            #endif
            context.DeleteType = this.DeleteType;
            context.ExperimentDefinitionIdentifier = this.ExperimentDefinitionIdentifier;
            #if MODULAR
            if (this.ExperimentDefinitionIdentifier == null && ParameterWasBound(nameof(this.ExperimentDefinitionIdentifier)))
            {
                WriteWarning("You are passing $null as a value for parameter ExperimentDefinitionIdentifier which is marked as required. In case you believe this parameter was incorrectly marked as required, report this by opening an issue at https://github.com/aws/aws-tools-for-powershell/issues.");
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
            var request = new Amazon.AppConfig.Model.DeleteExperimentDefinitionRequest();
            
            if (cmdletContext.ApplicationIdentifier != null)
            {
                request.ApplicationIdentifier = cmdletContext.ApplicationIdentifier;
            }
            if (cmdletContext.DeleteType != null)
            {
                request.DeleteType = cmdletContext.DeleteType;
            }
            if (cmdletContext.ExperimentDefinitionIdentifier != null)
            {
                request.ExperimentDefinitionIdentifier = cmdletContext.ExperimentDefinitionIdentifier;
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
        
        private Amazon.AppConfig.Model.DeleteExperimentDefinitionResponse CallAWSServiceOperation(IAmazonAppConfig client, Amazon.AppConfig.Model.DeleteExperimentDefinitionRequest request)
        {
            Utils.Common.WriteVerboseEndpointMessage(this, client.Config, "AWS AppConfig", "DeleteExperimentDefinition");
            try
            {
                return client.DeleteExperimentDefinitionAsync(request, _cancellationTokenSource.Token).GetAwaiter().GetResult();
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
            public System.String ApplicationIdentifier { get; set; }
            public Amazon.AppConfig.DeleteType DeleteType { get; set; }
            public System.String ExperimentDefinitionIdentifier { get; set; }
            public System.Func<Amazon.AppConfig.Model.DeleteExperimentDefinitionResponse, RemoveAPPCExperimentDefinitionCmdlet, object> Select { get; set; } =
                (response, cmdlet) => null;
        }
        
    }
}
