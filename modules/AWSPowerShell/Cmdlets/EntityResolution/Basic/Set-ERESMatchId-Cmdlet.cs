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
using Amazon.EntityResolution;
using Amazon.EntityResolution.Model;

namespace Amazon.PowerShell.Cmdlets.ERES
{
    /// <summary>
    /// Generates or retrieves Match IDs for records using a rule-based matching workflow.
    /// When you call this operation, it processes your records against the workflow's matching
    /// rules to identify potential matches. For existing records, it retrieves their Match
    /// IDs and associated rules. For records without matches, it generates new Match IDs.
    /// The operation saves results to Amazon S3. 
    /// 
    ///  
    /// <para>
    /// The processing type (<c>processingType</c>) you choose affects both the accuracy and
    /// response time of the operation. Additional charges apply for each API call, whether
    /// made through the Entity Resolution console or directly via the API. The rule-based
    /// matching workflow must exist and be active before calling this operation.
    /// </para>
    /// </summary>
    [Cmdlet("Set", "ERESMatchId", SupportsShouldProcess = true, ConfirmImpact = ConfirmImpact.Medium)]
    [OutputType("Amazon.EntityResolution.Model.GenerateMatchIdResponse")]
    [AWSCmdlet("Calls the AWS EntityResolution GenerateMatchId API operation.", Operation = new[] {"GenerateMatchId"}, SelectReturnType = typeof(Amazon.EntityResolution.Model.GenerateMatchIdResponse))]
    [AWSCmdletOutput("Amazon.EntityResolution.Model.GenerateMatchIdResponse",
        "This cmdlet returns an Amazon.EntityResolution.Model.GenerateMatchIdResponse object containing multiple properties."
    )]
    public partial class SetERESMatchIdCmdlet : AmazonEntityResolutionClientCmdlet, IExecutor
    {
        
        protected override bool IsSensitiveRequest { get; set; } = true;
        
        protected override bool IsGeneratedCmdlet { get; set; } = true;
        
        #region Parameter ProcessingType
        /// <summary>
        /// <para>
        /// <para>The processing mode that determines how Match IDs are generated and results are saved.
        /// Each mode provides different levels of accuracy, response time, and completeness of
        /// results.</para><para>If not specified, defaults to <c>CONSISTENT</c>.</para><para><c>CONSISTENT</c>: Performs immediate lookup and matching against all existing records,
        /// with results saved synchronously. Provides highest accuracy but slower response time.</para><para><c>EVENTUAL</c> (shown as <i>Background</i> in the console): Performs initial match
        /// ID lookup or generation immediately, with record updates processed asynchronously
        /// in the background. Offers faster initial response time, with complete matching results
        /// available later in S3. </para><para><c>EVENTUAL_NO_LOOKUP</c> (shown as <i>Quick ID generation</i> in the console): Generates
        /// new match IDs without checking existing matches, with updates processed asynchronously.
        /// Provides fastest response time but should only be used for records known to be unique.
        /// </para>
        /// </para>
        /// </summary>
        [System.Management.Automation.Parameter(ValueFromPipelineByPropertyName = true)]
        [AWSConstantClassSource("Amazon.EntityResolution.ProcessingType")]
        public Amazon.EntityResolution.ProcessingType ProcessingType { get; set; }
        #endregion
        
        #region Parameter Record
        /// <summary>
        /// <para>
        /// <para> The records to match.</para>
        /// </para>
        /// </summary>
        #if !MODULAR
        [System.Management.Automation.Parameter(ValueFromPipelineByPropertyName = true)]
        #else
        [System.Management.Automation.Parameter(ValueFromPipelineByPropertyName = true, Mandatory = true)]
        [System.Management.Automation.AllowEmptyCollection]
        [System.Management.Automation.AllowNull]
        #endif
        [Amazon.PowerShell.Common.AWSRequiredParameter]
        [Alias("Records")]
        public Amazon.EntityResolution.Model.Record[] Record { get; set; }
        #endregion
        
        #region Parameter WorkflowName
        /// <summary>
        /// <para>
        /// <para> The name of the rule-based matching workflow.</para>
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
        public System.String WorkflowName { get; set; }
        #endregion
        
        #region Parameter Select
        /// <summary>
        /// Use the -Select parameter to control the cmdlet output. The default value is '*'.
        /// Specifying -Select '*' will result in the cmdlet returning the whole service response (Amazon.EntityResolution.Model.GenerateMatchIdResponse).
        /// Specifying the name of a property of type Amazon.EntityResolution.Model.GenerateMatchIdResponse will result in that property being returned.
        /// Specifying -Select '^ParameterName' will result in the cmdlet returning the selected cmdlet parameter value.
        /// </summary>
        [System.Management.Automation.Parameter(ValueFromPipelineByPropertyName = true)]
        public string Select { get; set; } = "*";
        #endregion
        
        #region Parameter PassThru
        /// <summary>
        /// Changes the cmdlet behavior to return the value passed to the WorkflowName parameter.
        /// The -PassThru parameter is deprecated, use -Select '^WorkflowName' instead. This parameter will be removed in a future version.
        /// </summary>
        [System.Obsolete("The -PassThru parameter is deprecated, use -Select '^WorkflowName' instead. This parameter will be removed in a future version.")]
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
            
            var resourceIdentifiersText = FormatParameterValuesForConfirmationMsg(nameof(this.WorkflowName), MyInvocation.BoundParameters);
            if (!ConfirmShouldProceed(this.Force.IsPresent, resourceIdentifiersText, "Set-ERESMatchId (GenerateMatchId)"))
            {
                return;
            }
            
            var context = new CmdletContext();
            
            // allow for manipulation of parameters prior to loading into context
            PreExecutionContextLoad(context);
            
            #pragma warning disable CS0618, CS0612 //A class member was marked with the Obsolete attribute
            if (ParameterWasBound(nameof(this.Select)))
            {
                context.Select = CreateSelectDelegate<Amazon.EntityResolution.Model.GenerateMatchIdResponse, SetERESMatchIdCmdlet>(Select) ??
                    throw new System.ArgumentException("Invalid value for -Select parameter.", nameof(this.Select));
                if (this.PassThru.IsPresent)
                {
                    throw new System.ArgumentException("-PassThru cannot be used when -Select is specified.", nameof(this.Select));
                }
            }
            else if (this.PassThru.IsPresent)
            {
                context.Select = (response, cmdlet) => this.WorkflowName;
            }
            #pragma warning restore CS0618, CS0612 //A class member was marked with the Obsolete attribute
            context.ProcessingType = this.ProcessingType;
            if (this.Record != null)
            {
                context.Record = new List<Amazon.EntityResolution.Model.Record>(this.Record);
            }
            #if MODULAR
            if (this.Record == null && ParameterWasBound(nameof(this.Record)))
            {
                WriteWarning("You are passing $null as a value for parameter Record which is marked as required. In case you believe this parameter was incorrectly marked as required, report this by opening an issue at https://github.com/aws/aws-tools-for-powershell/issues.");
            }
            #endif
            context.WorkflowName = this.WorkflowName;
            #if MODULAR
            if (this.WorkflowName == null && ParameterWasBound(nameof(this.WorkflowName)))
            {
                WriteWarning("You are passing $null as a value for parameter WorkflowName which is marked as required. In case you believe this parameter was incorrectly marked as required, report this by opening an issue at https://github.com/aws/aws-tools-for-powershell/issues.");
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
            var request = new Amazon.EntityResolution.Model.GenerateMatchIdRequest();
            
            if (cmdletContext.ProcessingType != null)
            {
                request.ProcessingType = cmdletContext.ProcessingType;
            }
            if (cmdletContext.Record != null)
            {
                request.Records = cmdletContext.Record;
            }
            if (cmdletContext.WorkflowName != null)
            {
                request.WorkflowName = cmdletContext.WorkflowName;
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
        
        private Amazon.EntityResolution.Model.GenerateMatchIdResponse CallAWSServiceOperation(IAmazonEntityResolution client, Amazon.EntityResolution.Model.GenerateMatchIdRequest request)
        {
            Utils.Common.WriteVerboseEndpointMessage(this, client.Config, "AWS EntityResolution", "GenerateMatchId");
            try
            {
                #if DESKTOP
                return client.GenerateMatchId(request);
                #elif CORECLR
                return client.GenerateMatchIdAsync(request).GetAwaiter().GetResult();
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
            public Amazon.EntityResolution.ProcessingType ProcessingType { get; set; }
            public List<Amazon.EntityResolution.Model.Record> Record { get; set; }
            public System.String WorkflowName { get; set; }
            public System.Func<Amazon.EntityResolution.Model.GenerateMatchIdResponse, SetERESMatchIdCmdlet, object> Select { get; set; } =
                (response, cmdlet) => response;
        }
        
    }
}
