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
using Amazon.MediaLive;
using Amazon.MediaLive.Model;

namespace Amazon.PowerShell.Cmdlets.EML
{
    /// <summary>
    /// Delete a program from a multiplex.
    /// </summary>
    [Cmdlet("Remove", "EMLMultiplexProgram", SupportsShouldProcess = true, ConfirmImpact = ConfirmImpact.High)]
    [OutputType("Amazon.MediaLive.Model.DeleteMultiplexProgramResponse")]
    [AWSCmdlet("Calls the AWS Elemental MediaLive DeleteMultiplexProgram API operation.", Operation = new[] {"DeleteMultiplexProgram"}, SelectReturnType = typeof(Amazon.MediaLive.Model.DeleteMultiplexProgramResponse))]
    [AWSCmdletOutput("Amazon.MediaLive.Model.DeleteMultiplexProgramResponse",
        "This cmdlet returns an Amazon.MediaLive.Model.DeleteMultiplexProgramResponse object containing multiple properties."
    )]
    public partial class RemoveEMLMultiplexProgramCmdlet : AmazonMediaLiveClientCmdlet, IExecutor
    {
        
        protected override bool IsGeneratedCmdlet { get; set; } = true;
        
        #region Parameter MultiplexId
        /// <summary>
        /// <para>
        /// The ID of the multiplex that the program belongs
        /// to.
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
        public System.String MultiplexId { get; set; }
        #endregion
        
        #region Parameter ProgramName
        /// <summary>
        /// <para>
        /// The multiplex program name.
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
        public System.String ProgramName { get; set; }
        #endregion
        
        #region Parameter Select
        /// <summary>
        /// Use the -Select parameter to control the cmdlet output. The default value is '*'.
        /// Specifying -Select '*' will result in the cmdlet returning the whole service response (Amazon.MediaLive.Model.DeleteMultiplexProgramResponse).
        /// Specifying the name of a property of type Amazon.MediaLive.Model.DeleteMultiplexProgramResponse will result in that property being returned.
        /// Specifying -Select '^ParameterName' will result in the cmdlet returning the selected cmdlet parameter value.
        /// </summary>
        [System.Management.Automation.Parameter(ValueFromPipelineByPropertyName = true)]
        public string Select { get; set; } = "*";
        #endregion
        
        #region Parameter PassThru
        /// <summary>
        /// Changes the cmdlet behavior to return the value passed to the ProgramName parameter.
        /// The -PassThru parameter is deprecated, use -Select '^ProgramName' instead. This parameter will be removed in a future version.
        /// </summary>
        [System.Obsolete("The -PassThru parameter is deprecated, use -Select '^ProgramName' instead. This parameter will be removed in a future version.")]
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
            
            var resourceIdentifiersText = FormatParameterValuesForConfirmationMsg(nameof(this.ProgramName), MyInvocation.BoundParameters);
            if (!ConfirmShouldProceed(this.Force.IsPresent, resourceIdentifiersText, "Remove-EMLMultiplexProgram (DeleteMultiplexProgram)"))
            {
                return;
            }
            
            var context = new CmdletContext();
            
            // allow for manipulation of parameters prior to loading into context
            PreExecutionContextLoad(context);
            
            #pragma warning disable CS0618, CS0612 //A class member was marked with the Obsolete attribute
            if (ParameterWasBound(nameof(this.Select)))
            {
                context.Select = CreateSelectDelegate<Amazon.MediaLive.Model.DeleteMultiplexProgramResponse, RemoveEMLMultiplexProgramCmdlet>(Select) ??
                    throw new System.ArgumentException("Invalid value for -Select parameter.", nameof(this.Select));
                if (this.PassThru.IsPresent)
                {
                    throw new System.ArgumentException("-PassThru cannot be used when -Select is specified.", nameof(this.Select));
                }
            }
            else if (this.PassThru.IsPresent)
            {
                context.Select = (response, cmdlet) => this.ProgramName;
            }
            #pragma warning restore CS0618, CS0612 //A class member was marked with the Obsolete attribute
            context.MultiplexId = this.MultiplexId;
            #if MODULAR
            if (this.MultiplexId == null && ParameterWasBound(nameof(this.MultiplexId)))
            {
                WriteWarning("You are passing $null as a value for parameter MultiplexId which is marked as required. In case you believe this parameter was incorrectly marked as required, report this by opening an issue at https://github.com/aws/aws-tools-for-powershell/issues.");
            }
            #endif
            context.ProgramName = this.ProgramName;
            #if MODULAR
            if (this.ProgramName == null && ParameterWasBound(nameof(this.ProgramName)))
            {
                WriteWarning("You are passing $null as a value for parameter ProgramName which is marked as required. In case you believe this parameter was incorrectly marked as required, report this by opening an issue at https://github.com/aws/aws-tools-for-powershell/issues.");
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
            var request = new Amazon.MediaLive.Model.DeleteMultiplexProgramRequest();
            
            if (cmdletContext.MultiplexId != null)
            {
                request.MultiplexId = cmdletContext.MultiplexId;
            }
            if (cmdletContext.ProgramName != null)
            {
                request.ProgramName = cmdletContext.ProgramName;
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
        
        private Amazon.MediaLive.Model.DeleteMultiplexProgramResponse CallAWSServiceOperation(IAmazonMediaLive client, Amazon.MediaLive.Model.DeleteMultiplexProgramRequest request)
        {
            Utils.Common.WriteVerboseEndpointMessage(this, client.Config, "AWS Elemental MediaLive", "DeleteMultiplexProgram");
            try
            {
                #if DESKTOP
                return client.DeleteMultiplexProgram(request);
                #elif CORECLR
                return client.DeleteMultiplexProgramAsync(request).GetAwaiter().GetResult();
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
            public System.String MultiplexId { get; set; }
            public System.String ProgramName { get; set; }
            public System.Func<Amazon.MediaLive.Model.DeleteMultiplexProgramResponse, RemoveEMLMultiplexProgramCmdlet, object> Select { get; set; } =
                (response, cmdlet) => response;
        }
        
    }
}
