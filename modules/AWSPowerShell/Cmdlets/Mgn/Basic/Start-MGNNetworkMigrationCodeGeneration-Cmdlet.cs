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
using Amazon.Mgn;
using Amazon.Mgn.Model;

#pragma warning disable CS0618, CS0612
namespace Amazon.PowerShell.Cmdlets.MGN
{
    /// <summary>
    /// Starts a code generation job to convert network migration mappings into infrastructure-as-code
    /// templates.
    /// </summary>
    [Cmdlet("Start", "MGNNetworkMigrationCodeGeneration", SupportsShouldProcess = true, ConfirmImpact = ConfirmImpact.Medium)]
    [OutputType("System.String")]
    [AWSCmdlet("Calls the Application Migration Service StartNetworkMigrationCodeGeneration API operation.", Operation = new[] {"StartNetworkMigrationCodeGeneration"}, SelectReturnType = typeof(Amazon.Mgn.Model.StartNetworkMigrationCodeGenerationResponse))]
    [AWSCmdletOutput("System.String or Amazon.Mgn.Model.StartNetworkMigrationCodeGenerationResponse",
        "This cmdlet returns a System.String object.",
        "The service call response (type Amazon.Mgn.Model.StartNetworkMigrationCodeGenerationResponse) can be returned by specifying '-Select *'."
    )]
    public partial class StartMGNNetworkMigrationCodeGenerationCmdlet : AmazonMgnClientCmdlet, IExecutor
    {
        
        protected override bool IsGeneratedCmdlet { get; set; } = true;
        private readonly CancellationTokenSource _cancellationTokenSource = new CancellationTokenSource();
        
        #region Parameter CodeGenerationOutputFormatType
        /// <summary>
        /// <para>
        /// <para>The output format types for code generation, such as CloudFormation or Terraform.</para><para />
        /// Starting with version 4 of the SDK this property will default to null. If no data for this property is returned
        /// from the service the property will also be null. This was changed to improve performance and allow the SDK and caller
        /// to distinguish between a property not set or a property being empty to clear out a value. To retain the previous
        /// SDK behavior set the AWSConfigs.InitializeCollections static property to true.
        /// </para>
        /// </summary>
        [System.Management.Automation.Parameter(ValueFromPipelineByPropertyName = true)]
        [Alias("CodeGenerationOutputFormatTypes")]
        public System.String[] CodeGenerationOutputFormatType { get; set; }
        #endregion
        
        #region Parameter NetworkMigrationDefinitionID
        /// <summary>
        /// <para>
        /// <para>The unique identifier of the network migration definition.</para>
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
        public System.String NetworkMigrationDefinitionID { get; set; }
        #endregion
        
        #region Parameter NetworkMigrationExecutionID
        /// <summary>
        /// <para>
        /// <para>The unique identifier of the network migration execution.</para>
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
        public System.String NetworkMigrationExecutionID { get; set; }
        #endregion
        
        #region Parameter Select
        /// <summary>
        /// Use the -Select parameter to control the cmdlet output. The default value is 'JobID'.
        /// Specifying -Select '*' will result in the cmdlet returning the whole service response (Amazon.Mgn.Model.StartNetworkMigrationCodeGenerationResponse).
        /// Specifying the name of a property of type Amazon.Mgn.Model.StartNetworkMigrationCodeGenerationResponse will result in that property being returned.
        /// Specifying -Select '^ParameterName' will result in the cmdlet returning the selected cmdlet parameter value.
        /// </summary>
        [System.Management.Automation.Parameter(ValueFromPipelineByPropertyName = true)]
        public string Select { get; set; } = "JobID";
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
                nameof(this.NetworkMigrationDefinitionID),
                nameof(this.NetworkMigrationExecutionID)
            };
            var resourceIdentifiersText = FormatParameterValuesForConfirmationMsg(targetParameterNames, MyInvocation.BoundParameters);
            if (!ConfirmShouldProceed(this.Force.IsPresent, resourceIdentifiersText, "Start-MGNNetworkMigrationCodeGeneration (StartNetworkMigrationCodeGeneration)"))
            {
                return;
            }
            
            var context = new CmdletContext();
            
            // allow for manipulation of parameters prior to loading into context
            PreExecutionContextLoad(context);
            
            if (ParameterWasBound(nameof(this.Select)))
            {
                context.Select = CreateSelectDelegate<Amazon.Mgn.Model.StartNetworkMigrationCodeGenerationResponse, StartMGNNetworkMigrationCodeGenerationCmdlet>(Select) ??
                    throw new System.ArgumentException("Invalid value for -Select parameter.", nameof(this.Select));
            }
            if (this.CodeGenerationOutputFormatType != null)
            {
                context.CodeGenerationOutputFormatType = new List<System.String>(this.CodeGenerationOutputFormatType);
            }
            context.NetworkMigrationDefinitionID = this.NetworkMigrationDefinitionID;
            #if MODULAR
            if (this.NetworkMigrationDefinitionID == null && ParameterWasBound(nameof(this.NetworkMigrationDefinitionID)))
            {
                WriteWarning("You are passing $null as a value for parameter NetworkMigrationDefinitionID which is marked as required. In case you believe this parameter was incorrectly marked as required, report this by opening an issue at https://github.com/aws/aws-tools-for-powershell/issues.");
            }
            #endif
            context.NetworkMigrationExecutionID = this.NetworkMigrationExecutionID;
            #if MODULAR
            if (this.NetworkMigrationExecutionID == null && ParameterWasBound(nameof(this.NetworkMigrationExecutionID)))
            {
                WriteWarning("You are passing $null as a value for parameter NetworkMigrationExecutionID which is marked as required. In case you believe this parameter was incorrectly marked as required, report this by opening an issue at https://github.com/aws/aws-tools-for-powershell/issues.");
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
            var request = new Amazon.Mgn.Model.StartNetworkMigrationCodeGenerationRequest();
            
            if (cmdletContext.CodeGenerationOutputFormatType != null)
            {
                request.CodeGenerationOutputFormatTypes = cmdletContext.CodeGenerationOutputFormatType;
            }
            if (cmdletContext.NetworkMigrationDefinitionID != null)
            {
                request.NetworkMigrationDefinitionID = cmdletContext.NetworkMigrationDefinitionID;
            }
            if (cmdletContext.NetworkMigrationExecutionID != null)
            {
                request.NetworkMigrationExecutionID = cmdletContext.NetworkMigrationExecutionID;
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
        
        private Amazon.Mgn.Model.StartNetworkMigrationCodeGenerationResponse CallAWSServiceOperation(IAmazonMgn client, Amazon.Mgn.Model.StartNetworkMigrationCodeGenerationRequest request)
        {
            Utils.Common.WriteVerboseEndpointMessage(this, client.Config, "Application Migration Service", "StartNetworkMigrationCodeGeneration");
            try
            {
                return client.StartNetworkMigrationCodeGenerationAsync(request, _cancellationTokenSource.Token).GetAwaiter().GetResult();
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
            public List<System.String> CodeGenerationOutputFormatType { get; set; }
            public System.String NetworkMigrationDefinitionID { get; set; }
            public System.String NetworkMigrationExecutionID { get; set; }
            public System.Func<Amazon.Mgn.Model.StartNetworkMigrationCodeGenerationResponse, StartMGNNetworkMigrationCodeGenerationCmdlet, object> Select { get; set; } =
                (response, cmdlet) => response.JobID;
        }
        
    }
}
