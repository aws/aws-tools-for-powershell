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
using Amazon.Route53RecoveryControlConfig;
using Amazon.Route53RecoveryControlConfig.Model;

namespace Amazon.PowerShell.Cmdlets.R53RC
{
    /// <summary>
    /// Displays details about a routing control. A routing control has one of two states:
    /// ON and OFF. You can map the routing control state to the state of an Amazon Route
    /// 53 health check, which can be used to control routing.
    /// 
    ///  
    /// <para>
    /// To get or update the routing control state, see the Recovery Cluster (data plane)
    /// API actions for Amazon Route 53 Application Recovery Controller.
    /// </para>
    /// </summary>
    [Cmdlet("Get", "R53RCRoutingControl")]
    [OutputType("Amazon.Route53RecoveryControlConfig.Model.RoutingControl")]
    [AWSCmdlet("Calls the AWS Route53 Recovery Control Config DescribeRoutingControl API operation.", Operation = new[] {"DescribeRoutingControl"}, SelectReturnType = typeof(Amazon.Route53RecoveryControlConfig.Model.DescribeRoutingControlResponse))]
    [AWSCmdletOutput("Amazon.Route53RecoveryControlConfig.Model.RoutingControl or Amazon.Route53RecoveryControlConfig.Model.DescribeRoutingControlResponse",
        "This cmdlet returns an Amazon.Route53RecoveryControlConfig.Model.RoutingControl object.",
        "The service call response (type Amazon.Route53RecoveryControlConfig.Model.DescribeRoutingControlResponse) can be returned by specifying '-Select *'."
    )]
    public partial class GetR53RCRoutingControlCmdlet : AmazonRoute53RecoveryControlConfigClientCmdlet, IExecutor
    {
        
        protected override bool IsGeneratedCmdlet { get; set; } = true;
        
        #region Parameter RoutingControlArn
        /// <summary>
        /// <para>
        /// <para>The Amazon Resource Name (ARN) of the routing control.</para>
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
        public System.String RoutingControlArn { get; set; }
        #endregion
        
        #region Parameter Select
        /// <summary>
        /// Use the -Select parameter to control the cmdlet output. The default value is 'RoutingControl'.
        /// Specifying -Select '*' will result in the cmdlet returning the whole service response (Amazon.Route53RecoveryControlConfig.Model.DescribeRoutingControlResponse).
        /// Specifying the name of a property of type Amazon.Route53RecoveryControlConfig.Model.DescribeRoutingControlResponse will result in that property being returned.
        /// Specifying -Select '^ParameterName' will result in the cmdlet returning the selected cmdlet parameter value.
        /// </summary>
        [System.Management.Automation.Parameter(ValueFromPipelineByPropertyName = true)]
        public string Select { get; set; } = "RoutingControl";
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
                context.Select = CreateSelectDelegate<Amazon.Route53RecoveryControlConfig.Model.DescribeRoutingControlResponse, GetR53RCRoutingControlCmdlet>(Select) ??
                    throw new System.ArgumentException("Invalid value for -Select parameter.", nameof(this.Select));
            }
            context.RoutingControlArn = this.RoutingControlArn;
            #if MODULAR
            if (this.RoutingControlArn == null && ParameterWasBound(nameof(this.RoutingControlArn)))
            {
                WriteWarning("You are passing $null as a value for parameter RoutingControlArn which is marked as required. In case you believe this parameter was incorrectly marked as required, report this by opening an issue at https://github.com/aws/aws-tools-for-powershell/issues.");
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
            var request = new Amazon.Route53RecoveryControlConfig.Model.DescribeRoutingControlRequest();
            
            if (cmdletContext.RoutingControlArn != null)
            {
                request.RoutingControlArn = cmdletContext.RoutingControlArn;
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
        
        private Amazon.Route53RecoveryControlConfig.Model.DescribeRoutingControlResponse CallAWSServiceOperation(IAmazonRoute53RecoveryControlConfig client, Amazon.Route53RecoveryControlConfig.Model.DescribeRoutingControlRequest request)
        {
            Utils.Common.WriteVerboseEndpointMessage(this, client.Config, "AWS Route53 Recovery Control Config", "DescribeRoutingControl");
            try
            {
                #if DESKTOP
                return client.DescribeRoutingControl(request);
                #elif CORECLR
                return client.DescribeRoutingControlAsync(request).GetAwaiter().GetResult();
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
            public System.String RoutingControlArn { get; set; }
            public System.Func<Amazon.Route53RecoveryControlConfig.Model.DescribeRoutingControlResponse, GetR53RCRoutingControlCmdlet, object> Select { get; set; } =
                (response, cmdlet) => response.RoutingControl;
        }
        
    }
}
