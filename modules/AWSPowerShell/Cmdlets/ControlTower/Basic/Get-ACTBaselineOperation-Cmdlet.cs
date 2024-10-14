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
using Amazon.ControlTower;
using Amazon.ControlTower.Model;

namespace Amazon.PowerShell.Cmdlets.ACT
{
    /// <summary>
    /// Returns the details of an asynchronous baseline operation, as initiated by any of
    /// these APIs: <c>EnableBaseline</c>, <c>DisableBaseline</c>, <c>UpdateEnabledBaseline</c>,
    /// <c>ResetEnabledBaseline</c>. A status message is displayed in case of operation failure.
    /// For usage examples, see <a href="https://docs.aws.amazon.com/controltower/latest/userguide/baseline-api-examples.html"><i>the Amazon Web Services Control Tower User Guide</i></a>.
    /// </summary>
    [Cmdlet("Get", "ACTBaselineOperation")]
    [OutputType("Amazon.ControlTower.Model.BaselineOperation")]
    [AWSCmdlet("Calls the AWS Control Tower GetBaselineOperation API operation.", Operation = new[] {"GetBaselineOperation"}, SelectReturnType = typeof(Amazon.ControlTower.Model.GetBaselineOperationResponse))]
    [AWSCmdletOutput("Amazon.ControlTower.Model.BaselineOperation or Amazon.ControlTower.Model.GetBaselineOperationResponse",
        "This cmdlet returns an Amazon.ControlTower.Model.BaselineOperation object.",
        "The service call response (type Amazon.ControlTower.Model.GetBaselineOperationResponse) can be returned by specifying '-Select *'."
    )]
    public partial class GetACTBaselineOperationCmdlet : AmazonControlTowerClientCmdlet, IExecutor
    {
        
        protected override bool IsGeneratedCmdlet { get; set; } = true;
        
        #region Parameter OperationIdentifier
        /// <summary>
        /// <para>
        /// <para>The operation ID returned from mutating asynchronous APIs (Enable, Disable, Update,
        /// Reset).</para>
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
        public System.String OperationIdentifier { get; set; }
        #endregion
        
        #region Parameter Select
        /// <summary>
        /// Use the -Select parameter to control the cmdlet output. The default value is 'BaselineOperation'.
        /// Specifying -Select '*' will result in the cmdlet returning the whole service response (Amazon.ControlTower.Model.GetBaselineOperationResponse).
        /// Specifying the name of a property of type Amazon.ControlTower.Model.GetBaselineOperationResponse will result in that property being returned.
        /// Specifying -Select '^ParameterName' will result in the cmdlet returning the selected cmdlet parameter value.
        /// </summary>
        [System.Management.Automation.Parameter(ValueFromPipelineByPropertyName = true)]
        public string Select { get; set; } = "BaselineOperation";
        #endregion
        
        #region Parameter PassThru
        /// <summary>
        /// Changes the cmdlet behavior to return the value passed to the OperationIdentifier parameter.
        /// The -PassThru parameter is deprecated, use -Select '^OperationIdentifier' instead. This parameter will be removed in a future version.
        /// </summary>
        [System.Obsolete("The -PassThru parameter is deprecated, use -Select '^OperationIdentifier' instead. This parameter will be removed in a future version.")]
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
                context.Select = CreateSelectDelegate<Amazon.ControlTower.Model.GetBaselineOperationResponse, GetACTBaselineOperationCmdlet>(Select) ??
                    throw new System.ArgumentException("Invalid value for -Select parameter.", nameof(this.Select));
                if (this.PassThru.IsPresent)
                {
                    throw new System.ArgumentException("-PassThru cannot be used when -Select is specified.", nameof(this.Select));
                }
            }
            else if (this.PassThru.IsPresent)
            {
                context.Select = (response, cmdlet) => this.OperationIdentifier;
            }
            #pragma warning restore CS0618, CS0612 //A class member was marked with the Obsolete attribute
            context.OperationIdentifier = this.OperationIdentifier;
            #if MODULAR
            if (this.OperationIdentifier == null && ParameterWasBound(nameof(this.OperationIdentifier)))
            {
                WriteWarning("You are passing $null as a value for parameter OperationIdentifier which is marked as required. In case you believe this parameter was incorrectly marked as required, report this by opening an issue at https://github.com/aws/aws-tools-for-powershell/issues.");
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
            var request = new Amazon.ControlTower.Model.GetBaselineOperationRequest();
            
            if (cmdletContext.OperationIdentifier != null)
            {
                request.OperationIdentifier = cmdletContext.OperationIdentifier;
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
        
        private Amazon.ControlTower.Model.GetBaselineOperationResponse CallAWSServiceOperation(IAmazonControlTower client, Amazon.ControlTower.Model.GetBaselineOperationRequest request)
        {
            Utils.Common.WriteVerboseEndpointMessage(this, client.Config, "AWS Control Tower", "GetBaselineOperation");
            try
            {
                #if DESKTOP
                return client.GetBaselineOperation(request);
                #elif CORECLR
                return client.GetBaselineOperationAsync(request).GetAwaiter().GetResult();
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
            public System.String OperationIdentifier { get; set; }
            public System.Func<Amazon.ControlTower.Model.GetBaselineOperationResponse, GetACTBaselineOperationCmdlet, object> Select { get; set; } =
                (response, cmdlet) => response.BaselineOperation;
        }
        
    }
}
