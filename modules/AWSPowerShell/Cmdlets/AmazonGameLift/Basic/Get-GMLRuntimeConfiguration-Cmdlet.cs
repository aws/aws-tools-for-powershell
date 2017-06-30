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
using Amazon.GameLift;
using Amazon.GameLift.Model;

namespace Amazon.PowerShell.Cmdlets.GML
{
    /// <summary>
    /// Retrieves the current run-time configuration for the specified fleet. The run-time
    /// configuration tells Amazon GameLift how to launch server processes on instances in
    /// the fleet.
    /// 
    ///  
    /// <para>
    /// Fleet-related operations include:
    /// </para><ul><li><para><a>CreateFleet</a></para></li><li><para><a>ListFleets</a></para></li><li><para>
    /// Describe fleets:
    /// </para><ul><li><para><a>DescribeFleetAttributes</a></para></li><li><para><a>DescribeFleetPortSettings</a></para></li><li><para><a>DescribeFleetUtilization</a></para></li><li><para><a>DescribeRuntimeConfiguration</a></para></li><li><para><a>DescribeFleetEvents</a></para></li></ul></li><li><para>
    /// Update fleets:
    /// </para><ul><li><para><a>UpdateFleetAttributes</a></para></li><li><para><a>UpdateFleetCapacity</a></para></li><li><para><a>UpdateFleetPortSettings</a></para></li><li><para><a>UpdateRuntimeConfiguration</a></para></li></ul></li><li><para>
    /// Manage fleet capacity:
    /// </para><ul><li><para><a>DescribeFleetCapacity</a></para></li><li><para><a>UpdateFleetCapacity</a></para></li><li><para><a>PutScalingPolicy</a> (automatic scaling)
    /// </para></li><li><para><a>DescribeScalingPolicies</a> (automatic scaling)
    /// </para></li><li><para><a>DeleteScalingPolicy</a> (automatic scaling)
    /// </para></li><li><para><a>DescribeEC2InstanceLimits</a></para></li></ul></li><li><para><a>DeleteFleet</a></para></li></ul>
    /// </summary>
    [Cmdlet("Get", "GMLRuntimeConfiguration")]
    [OutputType("Amazon.GameLift.Model.RuntimeConfiguration")]
    [AWSCmdlet("Invokes the DescribeRuntimeConfiguration operation against Amazon GameLift Service.", Operation = new[] {"DescribeRuntimeConfiguration"})]
    [AWSCmdletOutput("Amazon.GameLift.Model.RuntimeConfiguration",
        "This cmdlet returns a RuntimeConfiguration object.",
        "The service call response (type Amazon.GameLift.Model.DescribeRuntimeConfigurationResponse) can also be referenced from properties attached to the cmdlet entry in the $AWSHistory stack."
    )]
    public partial class GetGMLRuntimeConfigurationCmdlet : AmazonGameLiftClientCmdlet, IExecutor
    {
        
        #region Parameter FleetId
        /// <summary>
        /// <para>
        /// <para>Unique identifier for a fleet to get the run-time configuration for.</para>
        /// </para>
        /// </summary>
        [System.Management.Automation.Parameter(Position = 0, ValueFromPipeline = true)]
        public System.String FleetId { get; set; }
        #endregion
        
        protected override void ProcessRecord()
        {
            base.ProcessRecord();
            
            var context = new CmdletContext
            {
                Region = this.Region,
                Credentials = this.CurrentCredentials
            };
            
            // allow for manipulation of parameters prior to loading into context
            PreExecutionContextLoad(context);
            
            context.FleetId = this.FleetId;
            
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
            var request = new Amazon.GameLift.Model.DescribeRuntimeConfigurationRequest();
            
            if (cmdletContext.FleetId != null)
            {
                request.FleetId = cmdletContext.FleetId;
            }
            
            CmdletOutput output;
            
            // issue call
            var client = Client ?? CreateClient(context.Credentials, context.Region);
            try
            {
                var response = CallAWSServiceOperation(client, request);
                Dictionary<string, object> notes = null;
                object pipelineOutput = response.RuntimeConfiguration;
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
        
        private Amazon.GameLift.Model.DescribeRuntimeConfigurationResponse CallAWSServiceOperation(IAmazonGameLift client, Amazon.GameLift.Model.DescribeRuntimeConfigurationRequest request)
        {
            Utils.Common.WriteVerboseEndpointMessage(this, client.Config, "Amazon GameLift Service", "DescribeRuntimeConfiguration");
            #if DESKTOP
            return client.DescribeRuntimeConfiguration(request);
            #elif CORECLR
            // todo: handle AggregateException and extract true service exception for rethrow
            var task = client.DescribeRuntimeConfigurationAsync(request);
            return task.Result;
            #else
                    #error "Unknown build edition"
            #endif
        }
        
        #endregion
        
        internal class CmdletContext : ExecutorContext
        {
            public System.String FleetId { get; set; }
        }
        
    }
}
