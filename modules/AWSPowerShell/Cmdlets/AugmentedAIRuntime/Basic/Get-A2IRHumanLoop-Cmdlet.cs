/*******************************************************************************
 *  Copyright 2012-2019 Amazon.com, Inc. or its affiliates. All Rights Reserved.
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
using Amazon.AugmentedAIRuntime;
using Amazon.AugmentedAIRuntime.Model;

namespace Amazon.PowerShell.Cmdlets.A2IR
{
    /// <summary>
    /// Returns information about the specified human loop. If the human loop was deleted,
    /// this operation will return a <c>ResourceNotFoundException</c> error.
    /// </summary>
    [Cmdlet("Get", "A2IRHumanLoop")]
    [OutputType("Amazon.AugmentedAIRuntime.Model.DescribeHumanLoopResponse")]
    [AWSCmdlet("Calls the Amazon Augmented AI (A2I) Runtime DescribeHumanLoop API operation.", Operation = new[] {"DescribeHumanLoop"}, SelectReturnType = typeof(Amazon.AugmentedAIRuntime.Model.DescribeHumanLoopResponse))]
    [AWSCmdletOutput("Amazon.AugmentedAIRuntime.Model.DescribeHumanLoopResponse",
        "This cmdlet returns an Amazon.AugmentedAIRuntime.Model.DescribeHumanLoopResponse object containing multiple properties."
    )]
    public partial class GetA2IRHumanLoopCmdlet : AmazonAugmentedAIRuntimeClientCmdlet, IExecutor
    {
        
        protected override bool IsGeneratedCmdlet { get; set; } = true;
        
        #region Parameter HumanLoopName
        /// <summary>
        /// <para>
        /// <para>The name of the human loop that you want information about.</para>
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
        public System.String HumanLoopName { get; set; }
        #endregion
        
        #region Parameter Select
        /// <summary>
        /// Use the -Select parameter to control the cmdlet output. The default value is '*'.
        /// Specifying -Select '*' will result in the cmdlet returning the whole service response (Amazon.AugmentedAIRuntime.Model.DescribeHumanLoopResponse).
        /// Specifying the name of a property of type Amazon.AugmentedAIRuntime.Model.DescribeHumanLoopResponse will result in that property being returned.
        /// Specifying -Select '^ParameterName' will result in the cmdlet returning the selected cmdlet parameter value.
        /// </summary>
        [System.Management.Automation.Parameter(ValueFromPipelineByPropertyName = true)]
        public string Select { get; set; } = "*";
        #endregion
        
        #region Parameter PassThru
        /// <summary>
        /// Changes the cmdlet behavior to return the value passed to the HumanLoopName parameter.
        /// The -PassThru parameter is deprecated, use -Select '^HumanLoopName' instead. This parameter will be removed in a future version.
        /// </summary>
        [System.Obsolete("The -PassThru parameter is deprecated, use -Select '^HumanLoopName' instead. This parameter will be removed in a future version.")]
        [System.Management.Automation.Parameter(ValueFromPipelineByPropertyName = true)]
        public SwitchParameter PassThru { get; set; }
        #endregion
        
        protected override void ProcessRecord()
        {
            this._AWSSignerType = "v4";
            base.ProcessRecord();
            
            var context = new CmdletContext();
            
            // allow for manipulation of parameters prior to loading into context
            PreExecutionContextLoad(context);
            
            #pragma warning disable CS0618, CS0612 //A class member was marked with the Obsolete attribute
            if (ParameterWasBound(nameof(this.Select)))
            {
                context.Select = CreateSelectDelegate<Amazon.AugmentedAIRuntime.Model.DescribeHumanLoopResponse, GetA2IRHumanLoopCmdlet>(Select) ??
                    throw new System.ArgumentException("Invalid value for -Select parameter.", nameof(this.Select));
                if (this.PassThru.IsPresent)
                {
                    throw new System.ArgumentException("-PassThru cannot be used when -Select is specified.", nameof(this.Select));
                }
            }
            else if (this.PassThru.IsPresent)
            {
                context.Select = (response, cmdlet) => this.HumanLoopName;
            }
            #pragma warning restore CS0618, CS0612 //A class member was marked with the Obsolete attribute
            context.HumanLoopName = this.HumanLoopName;
            #if MODULAR
            if (this.HumanLoopName == null && ParameterWasBound(nameof(this.HumanLoopName)))
            {
                WriteWarning("You are passing $null as a value for parameter HumanLoopName which is marked as required. In case you believe this parameter was incorrectly marked as required, report this by opening an issue at https://github.com/aws/aws-tools-for-powershell/issues.");
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
            var request = new Amazon.AugmentedAIRuntime.Model.DescribeHumanLoopRequest();
            
            if (cmdletContext.HumanLoopName != null)
            {
                request.HumanLoopName = cmdletContext.HumanLoopName;
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
        
        private Amazon.AugmentedAIRuntime.Model.DescribeHumanLoopResponse CallAWSServiceOperation(IAmazonAugmentedAIRuntime client, Amazon.AugmentedAIRuntime.Model.DescribeHumanLoopRequest request)
        {
            Utils.Common.WriteVerboseEndpointMessage(this, client.Config, "Amazon Augmented AI (A2I) Runtime", "DescribeHumanLoop");
            try
            {
                #if DESKTOP
                return client.DescribeHumanLoop(request);
                #elif CORECLR
                return client.DescribeHumanLoopAsync(request).GetAwaiter().GetResult();
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
            public System.String HumanLoopName { get; set; }
            public System.Func<Amazon.AugmentedAIRuntime.Model.DescribeHumanLoopResponse, GetA2IRHumanLoopCmdlet, object> Select { get; set; } =
                (response, cmdlet) => response;
        }
        
    }
}
