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
using Amazon.CodeDeploy;
using Amazon.CodeDeploy.Model;

namespace Amazon.PowerShell.Cmdlets.CD
{
    /// <summary>
    /// Creates a new deployment configuration.
    /// </summary>
    [Cmdlet("New", "CDDeploymentConfig", SupportsShouldProcess = true, ConfirmImpact = ConfirmImpact.Medium)]
    [OutputType("System.String")]
    [AWSCmdlet("Invokes the CreateDeploymentConfig operation against Amazon CodeDeploy.", Operation = new[] {"CreateDeploymentConfig"})]
    [AWSCmdletOutput("System.String",
        "This cmdlet returns a String object.",
        "The service call response (type CreateDeploymentConfigResponse) can also be referenced from properties attached to the cmdlet entry in the $AWSHistory stack."
    )]
    public class NewCDDeploymentConfigCmdlet : AmazonCodeDeployClientCmdlet, IExecutor
    {
        /// <summary>
        /// <para>
        /// <para>The name of the deployment configuration to create.</para>
        /// </para>
        /// </summary>
        [System.Management.Automation.Parameter]
        public String DeploymentConfigName { get; set; }
        
        /// <summary>
        /// <para>
        /// <para>The minimum healthy instances type:</para><ul><li>HOST_COUNT: The minimum number of healthy instances, as an absolute value.</li><li>FLEET_PERCENT: The minimum number of healthy instances, as a percentage of the
        /// total number of instances in the deployment.</li></ul><para>For example, for 9 instances, if a HOST_COUNT of 6 is specified, deploy to up to 3
        /// instances at a time. The deployment succeeds if 6 or more instances are successfully
        /// deployed to; otherwise, the deployment fails. If a FLEET_PERCENT of 40 is specified,
        /// deploy to up to 5 instances at a time. The deployment succeeds if 4 or more instances
        /// are successfully deployed to; otherwise, the deployment fails.</para><note>In a call to the get deployment configuration operation, CodeDeployDefault.OneAtATime
        /// will return a minimum healthy instances type of MOST_CONCURRENCY and a value of 1.
        /// This means a deployment to only one instances at a time. (You cannot set the type
        /// to MOST_CONCURRENCY, only to HOST_COUNT or FLEET_PERCENT.)</note>
        /// </para>
        /// </summary>
        [System.Management.Automation.Parameter]
        public MinimumHealthyHostsType MinimumHealthyHosts_Type { get; set; }
        
        /// <summary>
        /// <para>
        /// <para>The minimum healthy instances value.</para>
        /// </para>
        /// </summary>
        [System.Management.Automation.Parameter]
        public Int32 MinimumHealthyHosts_Value { get; set; }
        
        /// <summary>
        /// This parameter overrides confirmation prompts to force 
        /// the cmdlet to continue its operation. This parameter should always
        /// be used with caution.
        /// </summary>
        [System.Management.Automation.Parameter]
        public SwitchParameter Force { get; set; }
        
        
        protected override void ProcessRecord()
        {
            base.ProcessRecord();
            
            var resourceIdentifiersText = FormatParameterValuesForConfirmationMsg("DeploymentConfigName", MyInvocation.BoundParameters);
            if (!ConfirmShouldProceed(this.Force.IsPresent, resourceIdentifiersText, "New-CDDeploymentConfig (CreateDeploymentConfig)"))
            {
                return;
            }
            
            var context = new CmdletContext
            {
                Region = this.Region,
                Credentials = this.CurrentCredentials
            };
            
            context.DeploymentConfigName = this.DeploymentConfigName;
            context.MinimumHealthyHosts_Type = this.MinimumHealthyHosts_Type;
            if (ParameterWasBound("MinimumHealthyHosts_Value"))
                context.MinimumHealthyHosts_Value = this.MinimumHealthyHosts_Value;
            
            var output = Execute(context) as CmdletOutput;
            ProcessOutput(output);
        }
        
        #region IExecutor Members
        
        public object Execute(ExecutorContext context)
        {
            var cmdletContext = context as CmdletContext;
            // create request
            var request = new CreateDeploymentConfigRequest();
            
            if (cmdletContext.DeploymentConfigName != null)
            {
                request.DeploymentConfigName = cmdletContext.DeploymentConfigName;
            }
            
             // populate MinimumHealthyHosts
            bool requestMinimumHealthyHostsIsNull = true;
            request.MinimumHealthyHosts = new MinimumHealthyHosts();
            MinimumHealthyHostsType requestMinimumHealthyHosts_minimumHealthyHosts_Type = null;
            if (cmdletContext.MinimumHealthyHosts_Type != null)
            {
                requestMinimumHealthyHosts_minimumHealthyHosts_Type = cmdletContext.MinimumHealthyHosts_Type;
            }
            if (requestMinimumHealthyHosts_minimumHealthyHosts_Type != null)
            {
                request.MinimumHealthyHosts.Type = requestMinimumHealthyHosts_minimumHealthyHosts_Type;
                requestMinimumHealthyHostsIsNull = false;
            }
            Int32? requestMinimumHealthyHosts_minimumHealthyHosts_Value = null;
            if (cmdletContext.MinimumHealthyHosts_Value != null)
            {
                requestMinimumHealthyHosts_minimumHealthyHosts_Value = cmdletContext.MinimumHealthyHosts_Value.Value;
            }
            if (requestMinimumHealthyHosts_minimumHealthyHosts_Value != null)
            {
                request.MinimumHealthyHosts.Value = requestMinimumHealthyHosts_minimumHealthyHosts_Value.Value;
                requestMinimumHealthyHostsIsNull = false;
            }
             // determine if request.MinimumHealthyHosts should be set to null
            if (requestMinimumHealthyHostsIsNull)
            {
                request.MinimumHealthyHosts = null;
            }
            
            CmdletOutput output;
            
            // issue call
            var client = Client ?? CreateClient(context.Credentials, context.Region);
            try
            {
                var response = client.CreateDeploymentConfig(request);
                Dictionary<string, object> notes = null;
                object pipelineOutput = response.DeploymentConfigId;
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
        
        
        internal class CmdletContext : ExecutorContext
        {
            public String DeploymentConfigName { get; set; }
            public MinimumHealthyHostsType MinimumHealthyHosts_Type { get; set; }
            public Int32? MinimumHealthyHosts_Value { get; set; }
        }
        
    }
}
