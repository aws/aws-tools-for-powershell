/*******************************************************************************
 *  Copyright 2012-2015 Amazon.com, Inc. or its affiliates. All Rights Reserved.
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
using Amazon.StorageGateway;
using Amazon.StorageGateway.Model;

namespace Amazon.PowerShell.Cmdlets.SG
{
    /// <summary>
    /// Shuts down a gateway. To specify which gateway to shut down, use the Amazon Resource
    /// Name (ARN) of the gateway in the body of your request.
    /// 
    ///  
    /// <para>
    /// The operation shuts down the gateway service component running in the gateway's virtual
    /// machine (VM) and not the host VM.
    /// </para><note><para>
    /// If you want to shut down the VM, it is recommended that you first shut down the gateway
    /// component in the VM to avoid unpredictable conditions.
    /// </para></note><para>
    /// After the gateway is shutdown, you cannot call any other API except <a>StartGateway</a>,
    /// <a>DescribeGatewayInformation</a>, and <a>ListGateways</a>. For more information,
    /// see <a>ActivateGateway</a>. Your applications cannot read from or write to the gateway's
    /// storage volumes, and there are no snapshots taken.
    /// </para><note><para>
    /// When you make a shutdown request, you will get a <code>200 OK</code> success response
    /// immediately. However, it might take some time for the gateway to shut down. You can
    /// call the <a>DescribeGatewayInformation</a> API to check the status. For more information,
    /// see <a>ActivateGateway</a>.
    /// </para></note><para>
    /// If do not intend to use the gateway again, you must delete the gateway (using <a>DeleteGateway</a>)
    /// to no longer pay software charges associated with the gateway.
    /// </para>
    /// </summary>
    [Cmdlet("Stop", "SGGateway", SupportsShouldProcess = true, ConfirmImpact = ConfirmImpact.Medium)]
    [OutputType("System.String")]
    [AWSCmdlet("Invokes the ShutdownGateway operation against AWS Storage Gateway.", Operation = new[] {"ShutdownGateway"})]
    [AWSCmdletOutput("System.String",
        "This cmdlet returns a String object.",
        "The service call response (type Amazon.StorageGateway.Model.ShutdownGatewayResponse) can also be referenced from properties attached to the cmdlet entry in the $AWSHistory stack."
    )]
    public partial class StopSGGatewayCmdlet : AmazonStorageGatewayClientCmdlet, IExecutor
    {
        
        #region Parameter GatewayARN
        /// <summary>
        /// <para>
        /// Documentation for this parameter is not currently available; please refer to the service API documentation.
        /// </para>
        /// </summary>
        [System.Management.Automation.Parameter(Position = 0, ValueFromPipelineByPropertyName = true, ValueFromPipeline = true)]
        public System.String GatewayARN { get; set; }
        #endregion
        
        #region Parameter Force
        /// <summary>
        /// This parameter overrides confirmation prompts to force 
        /// the cmdlet to continue its operation. This parameter should always
        /// be used with caution.
        /// </summary>
        [System.Management.Automation.Parameter]
        public SwitchParameter Force { get; set; }
        #endregion
        
        protected override void ProcessRecord()
        {
            base.ProcessRecord();
            
            var resourceIdentifiersText = FormatParameterValuesForConfirmationMsg("GatewayARN", MyInvocation.BoundParameters);
            if (!ConfirmShouldProceed(this.Force.IsPresent, resourceIdentifiersText, "Stop-SGGateway (ShutdownGateway)"))
            {
                return;
            }
            
            var context = new CmdletContext
            {
                Region = this.Region,
                Credentials = this.CurrentCredentials
            };
            
            // allow for manipulation of parameters prior to loading into context
            PreExecutionContextLoad(context);
            
            context.GatewayARN = this.GatewayARN;
            
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
            var request = new Amazon.StorageGateway.Model.ShutdownGatewayRequest();
            
            if (cmdletContext.GatewayARN != null)
            {
                request.GatewayARN = cmdletContext.GatewayARN;
            }
            
            CmdletOutput output;
            
            // issue call
            var client = Client ?? CreateClient(context.Credentials, context.Region);
            try
            {
                var response = CallAWSServiceOperation(client, request);
                Dictionary<string, object> notes = null;
                object pipelineOutput = response.GatewayARN;
                output = new CmdletOutput
                {
                    PipelineOutput = pipelineOutput,
                    ServiceResponse = response,
                    Notes = notes
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
        
        private Amazon.StorageGateway.Model.ShutdownGatewayResponse CallAWSServiceOperation(IAmazonStorageGateway client, Amazon.StorageGateway.Model.ShutdownGatewayRequest request)
        {
            Utils.Common.WriteVerboseEndpointMessage(this, client.Config, "AWS Storage Gateway", "ShutdownGateway");
            try
            {
                #if DESKTOP
                return client.ShutdownGateway(request);
                #elif CORECLR
                // todo: handle AggregateException and extract true service exception for rethrow
                var task = client.ShutdownGatewayAsync(request);
                return task.Result;
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
            public System.String GatewayARN { get; set; }
        }
        
    }
}
