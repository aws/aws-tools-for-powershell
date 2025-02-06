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
using Amazon.Athena;
using Amazon.Athena.Model;

namespace Amazon.PowerShell.Cmdlets.ATH
{
    /// <summary>
    /// Submits calculations for execution within a session. You can supply the code to run
    /// as an inline code block within the request.
    /// 
    ///  <note><para>
    /// The request syntax requires the <a>StartCalculationExecutionRequest$CodeBlock</a>
    /// parameter or the <a>CalculationConfiguration$CodeBlock</a> parameter, but not both.
    /// Because <a>CalculationConfiguration$CodeBlock</a> is deprecated, use the <a>StartCalculationExecutionRequest$CodeBlock</a>
    /// parameter instead.
    /// </para></note>
    /// </summary>
    [Cmdlet("Start", "ATHCalculationExecution", SupportsShouldProcess = true, ConfirmImpact = ConfirmImpact.Medium)]
    [OutputType("Amazon.Athena.Model.StartCalculationExecutionResponse")]
    [AWSCmdlet("Calls the Amazon Athena StartCalculationExecution API operation.", Operation = new[] {"StartCalculationExecution"}, SelectReturnType = typeof(Amazon.Athena.Model.StartCalculationExecutionResponse))]
    [AWSCmdletOutput("Amazon.Athena.Model.StartCalculationExecutionResponse",
        "This cmdlet returns an Amazon.Athena.Model.StartCalculationExecutionResponse object containing multiple properties."
    )]
    public partial class StartATHCalculationExecutionCmdlet : AmazonAthenaClientCmdlet, IExecutor
    {
        
        protected override bool IsGeneratedCmdlet { get; set; } = true;
        
        #region Parameter ClientRequestToken
        /// <summary>
        /// <para>
        /// <para>A unique case-sensitive string used to ensure the request to create the calculation
        /// is idempotent (executes only once). If another <c>StartCalculationExecutionRequest</c>
        /// is received, the same response is returned and another calculation is not created.
        /// If a parameter has changed, an error is returned.</para><important><para>This token is listed as not required because Amazon Web Services SDKs (for example
        /// the Amazon Web Services SDK for Java) auto-generate the token for users. If you are
        /// not using the Amazon Web Services SDK or the Amazon Web Services CLI, you must provide
        /// this token or the action will fail.</para></important>
        /// </para>
        /// </summary>
        [System.Management.Automation.Parameter(ValueFromPipelineByPropertyName = true)]
        public System.String ClientRequestToken { get; set; }
        #endregion
        
        #region Parameter CalculationConfiguration_CodeBlock
        /// <summary>
        /// <para>
        /// <para>A string that contains the code for the calculation.</para>
        /// </para>
        /// </summary>
        [System.Management.Automation.Parameter(ValueFromPipelineByPropertyName = true)]
        public System.String CalculationConfiguration_CodeBlock { get; set; }
        #endregion
        
        #region Parameter CodeBlock
        /// <summary>
        /// <para>
        /// <para>A string that contains the code of the calculation. Use this parameter instead of
        /// <a>CalculationConfiguration$CodeBlock</a>, which is deprecated.</para>
        /// </para>
        /// </summary>
        [System.Management.Automation.Parameter(ValueFromPipelineByPropertyName = true)]
        public System.String CodeBlock { get; set; }
        #endregion
        
        #region Parameter Description
        /// <summary>
        /// <para>
        /// <para>A description of the calculation.</para>
        /// </para>
        /// </summary>
        [System.Management.Automation.Parameter(ValueFromPipelineByPropertyName = true)]
        public System.String Description { get; set; }
        #endregion
        
        #region Parameter SessionId
        /// <summary>
        /// <para>
        /// <para>The session ID.</para>
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
        public System.String SessionId { get; set; }
        #endregion
        
        #region Parameter Select
        /// <summary>
        /// Use the -Select parameter to control the cmdlet output. The default value is '*'.
        /// Specifying -Select '*' will result in the cmdlet returning the whole service response (Amazon.Athena.Model.StartCalculationExecutionResponse).
        /// Specifying the name of a property of type Amazon.Athena.Model.StartCalculationExecutionResponse will result in that property being returned.
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
        
        protected override void ProcessRecord()
        {
            this._AWSSignerType = "v4";
            base.ProcessRecord();
            
            var resourceIdentifiersText = FormatParameterValuesForConfirmationMsg(nameof(this.SessionId), MyInvocation.BoundParameters);
            if (!ConfirmShouldProceed(this.Force.IsPresent, resourceIdentifiersText, "Start-ATHCalculationExecution (StartCalculationExecution)"))
            {
                return;
            }
            
            var context = new CmdletContext();
            
            // allow for manipulation of parameters prior to loading into context
            PreExecutionContextLoad(context);
            
            if (ParameterWasBound(nameof(this.Select)))
            {
                context.Select = CreateSelectDelegate<Amazon.Athena.Model.StartCalculationExecutionResponse, StartATHCalculationExecutionCmdlet>(Select) ??
                    throw new System.ArgumentException("Invalid value for -Select parameter.", nameof(this.Select));
            }
            context.CalculationConfiguration_CodeBlock = this.CalculationConfiguration_CodeBlock;
            context.ClientRequestToken = this.ClientRequestToken;
            context.CodeBlock = this.CodeBlock;
            context.Description = this.Description;
            context.SessionId = this.SessionId;
            #if MODULAR
            if (this.SessionId == null && ParameterWasBound(nameof(this.SessionId)))
            {
                WriteWarning("You are passing $null as a value for parameter SessionId which is marked as required. In case you believe this parameter was incorrectly marked as required, report this by opening an issue at https://github.com/aws/aws-tools-for-powershell/issues.");
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
            var request = new Amazon.Athena.Model.StartCalculationExecutionRequest();
            
            
             // populate CalculationConfiguration
            var requestCalculationConfigurationIsNull = true;
            request.CalculationConfiguration = new Amazon.Athena.Model.CalculationConfiguration();
            System.String requestCalculationConfiguration_calculationConfiguration_CodeBlock = null;
            if (cmdletContext.CalculationConfiguration_CodeBlock != null)
            {
                requestCalculationConfiguration_calculationConfiguration_CodeBlock = cmdletContext.CalculationConfiguration_CodeBlock;
            }
            if (requestCalculationConfiguration_calculationConfiguration_CodeBlock != null)
            {
                request.CalculationConfiguration.CodeBlock = requestCalculationConfiguration_calculationConfiguration_CodeBlock;
                requestCalculationConfigurationIsNull = false;
            }
             // determine if request.CalculationConfiguration should be set to null
            if (requestCalculationConfigurationIsNull)
            {
                request.CalculationConfiguration = null;
            }
            if (cmdletContext.ClientRequestToken != null)
            {
                request.ClientRequestToken = cmdletContext.ClientRequestToken;
            }
            if (cmdletContext.CodeBlock != null)
            {
                request.CodeBlock = cmdletContext.CodeBlock;
            }
            if (cmdletContext.Description != null)
            {
                request.Description = cmdletContext.Description;
            }
            if (cmdletContext.SessionId != null)
            {
                request.SessionId = cmdletContext.SessionId;
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
        
        private Amazon.Athena.Model.StartCalculationExecutionResponse CallAWSServiceOperation(IAmazonAthena client, Amazon.Athena.Model.StartCalculationExecutionRequest request)
        {
            Utils.Common.WriteVerboseEndpointMessage(this, client.Config, "Amazon Athena", "StartCalculationExecution");
            try
            {
                #if DESKTOP
                return client.StartCalculationExecution(request);
                #elif CORECLR
                return client.StartCalculationExecutionAsync(request).GetAwaiter().GetResult();
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
            public System.String CalculationConfiguration_CodeBlock { get; set; }
            public System.String ClientRequestToken { get; set; }
            public System.String CodeBlock { get; set; }
            public System.String Description { get; set; }
            public System.String SessionId { get; set; }
            public System.Func<Amazon.Athena.Model.StartCalculationExecutionResponse, StartATHCalculationExecutionCmdlet, object> Select { get; set; } =
                (response, cmdlet) => response;
        }
        
    }
}
