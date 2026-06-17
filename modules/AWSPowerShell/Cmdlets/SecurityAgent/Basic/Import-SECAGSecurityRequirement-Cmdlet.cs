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
using Amazon.SecurityAgent;
using Amazon.SecurityAgent.Model;

#pragma warning disable CS0618, CS0612
namespace Amazon.PowerShell.Cmdlets.SECAG
{
    /// <summary>
    /// Imports security requirements from uploaded documents into a customer managed security
    /// requirement pack. The import process asynchronously extracts and generates structured
    /// security requirements from the provided source files.
    /// </summary>
    [Cmdlet("Import", "SECAGSecurityRequirement", SupportsShouldProcess = true, ConfirmImpact = ConfirmImpact.Medium)]
    [OutputType("Amazon.SecurityAgent.Model.ImportSecurityRequirementsResponse")]
    [AWSCmdlet("Calls the AWS Security Agent ImportSecurityRequirements API operation.", Operation = new[] {"ImportSecurityRequirements"}, SelectReturnType = typeof(Amazon.SecurityAgent.Model.ImportSecurityRequirementsResponse))]
    [AWSCmdletOutput("Amazon.SecurityAgent.Model.ImportSecurityRequirementsResponse",
        "This cmdlet returns an Amazon.SecurityAgent.Model.ImportSecurityRequirementsResponse object containing multiple properties."
    )]
    public partial class ImportSECAGSecurityRequirementCmdlet : AmazonSecurityAgentClientCmdlet, IExecutor
    {
        
        protected override bool IsGeneratedCmdlet { get; set; } = true;
        private readonly CancellationTokenSource _cancellationTokenSource = new CancellationTokenSource();
        
        #region Parameter Input_Document
        /// <summary>
        /// <para>
        /// <para>The list of documents to extract security requirements from.</para><para />
        /// Starting with version 4 of the SDK this property will default to null. If no data for this property is returned
        /// from the service the property will also be null. This was changed to improve performance and allow the SDK and caller
        /// to distinguish between a property not set or a property being empty to clear out a value. To retain the previous
        /// SDK behavior set the AWSConfigs.InitializeCollections static property to true.
        /// </para>
        /// </summary>
        [System.Management.Automation.Parameter(ValueFromPipelineByPropertyName = true)]
        [Alias("Input_Documents")]
        public Amazon.SecurityAgent.Model.SecurityRequirementArtifact[] Input_Document { get; set; }
        #endregion
        
        #region Parameter PackId
        /// <summary>
        /// <para>
        /// <para>The unique identifier of the security requirement pack to import requirements into.</para>
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
        public System.String PackId { get; set; }
        #endregion
        
        #region Parameter Select
        /// <summary>
        /// Use the -Select parameter to control the cmdlet output. The default value is '*'.
        /// Specifying -Select '*' will result in the cmdlet returning the whole service response (Amazon.SecurityAgent.Model.ImportSecurityRequirementsResponse).
        /// Specifying the name of a property of type Amazon.SecurityAgent.Model.ImportSecurityRequirementsResponse will result in that property being returned.
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
            
            var resourceIdentifiersText = FormatParameterValuesForConfirmationMsg(nameof(this.PackId), MyInvocation.BoundParameters);
            if (!ConfirmShouldProceed(this.Force.IsPresent, resourceIdentifiersText, "Import-SECAGSecurityRequirement (ImportSecurityRequirements)"))
            {
                return;
            }
            
            var context = new CmdletContext();
            
            // allow for manipulation of parameters prior to loading into context
            PreExecutionContextLoad(context);
            
            if (ParameterWasBound(nameof(this.Select)))
            {
                context.Select = CreateSelectDelegate<Amazon.SecurityAgent.Model.ImportSecurityRequirementsResponse, ImportSECAGSecurityRequirementCmdlet>(Select) ??
                    throw new System.ArgumentException("Invalid value for -Select parameter.", nameof(this.Select));
            }
            if (this.Input_Document != null)
            {
                context.Input_Document = new List<Amazon.SecurityAgent.Model.SecurityRequirementArtifact>(this.Input_Document);
            }
            context.PackId = this.PackId;
            #if MODULAR
            if (this.PackId == null && ParameterWasBound(nameof(this.PackId)))
            {
                WriteWarning("You are passing $null as a value for parameter PackId which is marked as required. In case you believe this parameter was incorrectly marked as required, report this by opening an issue at https://github.com/aws/aws-tools-for-powershell/issues.");
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
            var request = new Amazon.SecurityAgent.Model.ImportSecurityRequirementsRequest();
            
            
             // populate Input
            var requestInputIsNull = true;
            request.Input = new Amazon.SecurityAgent.Model.ImportSource();
            List<Amazon.SecurityAgent.Model.SecurityRequirementArtifact> requestInput_input_Document = null;
            if (cmdletContext.Input_Document != null)
            {
                requestInput_input_Document = cmdletContext.Input_Document;
            }
            if (requestInput_input_Document != null)
            {
                request.Input.Documents = requestInput_input_Document;
                requestInputIsNull = false;
            }
             // determine if request.Input should be set to null
            if (requestInputIsNull)
            {
                request.Input = null;
            }
            if (cmdletContext.PackId != null)
            {
                request.PackId = cmdletContext.PackId;
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
        
        private Amazon.SecurityAgent.Model.ImportSecurityRequirementsResponse CallAWSServiceOperation(IAmazonSecurityAgent client, Amazon.SecurityAgent.Model.ImportSecurityRequirementsRequest request)
        {
            Utils.Common.WriteVerboseEndpointMessage(this, client.Config, "AWS Security Agent", "ImportSecurityRequirements");
            try
            {
                return client.ImportSecurityRequirementsAsync(request, _cancellationTokenSource.Token).GetAwaiter().GetResult();
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
            public List<Amazon.SecurityAgent.Model.SecurityRequirementArtifact> Input_Document { get; set; }
            public System.String PackId { get; set; }
            public System.Func<Amazon.SecurityAgent.Model.ImportSecurityRequirementsResponse, ImportSECAGSecurityRequirementCmdlet, object> Select { get; set; } =
                (response, cmdlet) => response;
        }
        
    }
}
