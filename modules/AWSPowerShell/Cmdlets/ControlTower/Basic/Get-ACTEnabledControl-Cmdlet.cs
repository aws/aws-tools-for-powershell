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
    /// Retrieves details about an enabled control. For usage examples, see the <a href="https://docs.aws.amazon.com/controltower/latest/controlreference/control-api-examples-short.html"><i>Controls Reference Guide</i></a>.
    /// </summary>
    [Cmdlet("Get", "ACTEnabledControl")]
    [OutputType("Amazon.ControlTower.Model.EnabledControlDetails")]
    [AWSCmdlet("Calls the AWS Control Tower GetEnabledControl API operation.", Operation = new[] {"GetEnabledControl"}, SelectReturnType = typeof(Amazon.ControlTower.Model.GetEnabledControlResponse))]
    [AWSCmdletOutput("Amazon.ControlTower.Model.EnabledControlDetails or Amazon.ControlTower.Model.GetEnabledControlResponse",
        "This cmdlet returns an Amazon.ControlTower.Model.EnabledControlDetails object.",
        "The service call response (type Amazon.ControlTower.Model.GetEnabledControlResponse) can be returned by specifying '-Select *'."
    )]
    public partial class GetACTEnabledControlCmdlet : AmazonControlTowerClientCmdlet, IExecutor
    {
        
        protected override bool IsGeneratedCmdlet { get; set; } = true;
        
        #region Parameter EnabledControlIdentifier
        /// <summary>
        /// <para>
        /// <para>The <c>controlIdentifier</c> of the enabled control.</para>
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
        public System.String EnabledControlIdentifier { get; set; }
        #endregion
        
        #region Parameter Select
        /// <summary>
        /// Use the -Select parameter to control the cmdlet output. The default value is 'EnabledControlDetails'.
        /// Specifying -Select '*' will result in the cmdlet returning the whole service response (Amazon.ControlTower.Model.GetEnabledControlResponse).
        /// Specifying the name of a property of type Amazon.ControlTower.Model.GetEnabledControlResponse will result in that property being returned.
        /// Specifying -Select '^ParameterName' will result in the cmdlet returning the selected cmdlet parameter value.
        /// </summary>
        [System.Management.Automation.Parameter(ValueFromPipelineByPropertyName = true)]
        public string Select { get; set; } = "EnabledControlDetails";
        #endregion
        
        protected override void ProcessRecord()
        {
            this._AWSSignerType = "v4";
            base.ProcessRecord();
            
            var context = new CmdletContext();
            
            // allow for manipulation of parameters prior to loading into context
            PreExecutionContextLoad(context);
            
            if (ParameterWasBound(nameof(this.Select)))
            {
                context.Select = CreateSelectDelegate<Amazon.ControlTower.Model.GetEnabledControlResponse, GetACTEnabledControlCmdlet>(Select) ??
                    throw new System.ArgumentException("Invalid value for -Select parameter.", nameof(this.Select));
            }
            context.EnabledControlIdentifier = this.EnabledControlIdentifier;
            #if MODULAR
            if (this.EnabledControlIdentifier == null && ParameterWasBound(nameof(this.EnabledControlIdentifier)))
            {
                WriteWarning("You are passing $null as a value for parameter EnabledControlIdentifier which is marked as required. In case you believe this parameter was incorrectly marked as required, report this by opening an issue at https://github.com/aws/aws-tools-for-powershell/issues.");
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
            var request = new Amazon.ControlTower.Model.GetEnabledControlRequest();
            
            if (cmdletContext.EnabledControlIdentifier != null)
            {
                request.EnabledControlIdentifier = cmdletContext.EnabledControlIdentifier;
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
        
        private Amazon.ControlTower.Model.GetEnabledControlResponse CallAWSServiceOperation(IAmazonControlTower client, Amazon.ControlTower.Model.GetEnabledControlRequest request)
        {
            Utils.Common.WriteVerboseEndpointMessage(this, client.Config, "AWS Control Tower", "GetEnabledControl");
            try
            {
                #if DESKTOP
                return client.GetEnabledControl(request);
                #elif CORECLR
                return client.GetEnabledControlAsync(request).GetAwaiter().GetResult();
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
            public System.String EnabledControlIdentifier { get; set; }
            public System.Func<Amazon.ControlTower.Model.GetEnabledControlResponse, GetACTEnabledControlCmdlet, object> Select { get; set; } =
                (response, cmdlet) => response.EnabledControlDetails;
        }
        
    }
}
