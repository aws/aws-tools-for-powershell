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
using Amazon.Redshift;
using Amazon.Redshift.Model;

namespace Amazon.PowerShell.Cmdlets.RS
{
    /// <summary>
    /// Sets one or more parameters of the specified parameter group to their default values
    /// and sets the source values of the parameters to "engine-default". To reset the entire
    /// parameter group specify the <i>ResetAllParameters</i> parameter. For parameter changes
    /// to take effect you must reboot any associated clusters.
    /// </summary>
    [Cmdlet("Reset", "RSClusterParameterGroup", SupportsShouldProcess = true, ConfirmImpact = ConfirmImpact.Medium)]
    [OutputType("Amazon.Redshift.Model.ResetClusterParameterGroupResult")]
    [AWSCmdlet("Invokes the ResetClusterParameterGroup operation against Amazon Redshift.", Operation = new[] {"ResetClusterParameterGroup"})]
    [AWSCmdletOutput("Amazon.Redshift.Model.ResetClusterParameterGroupResult",
        "This cmdlet returns a ResetClusterParameterGroupResult object containing multiple properties. The object can also be referenced from properties attached to the cmdlet entry in the $AWSHistory stack."
    )]
    public class ResetRSClusterParameterGroupCmdlet : AmazonRedshiftClientCmdlet, IExecutor
    {
        /// <summary>
        /// <para>
        /// <para> The name of the cluster parameter group to be reset. </para>
        /// </para>
        /// </summary>
        [System.Management.Automation.Parameter(Position = 0, ValueFromPipelineByPropertyName = true, ValueFromPipeline = true)]
        public String ParameterGroupName { get; set; }
        
        /// <summary>
        /// <para>
        /// <para> An array of names of parameters to be reset. If <i>ResetAllParameters</i> option
        /// is not used, then at least one parameter name must be supplied. </para><para>Constraints: A maximum of 20 parameters can be reset in a single request.</para>
        /// </para>
        /// </summary>
        [System.Management.Automation.Parameter]
        [Alias("Parameters")]
        public Amazon.Redshift.Model.Parameter[] Parameter { get; set; }
        
        /// <summary>
        /// <para>
        /// <para> If <code>true</code>, all parameters in the specified parameter group will be reset
        /// to their default values. </para><para>Default: <code>true</code></para>
        /// </para>
        /// </summary>
        [System.Management.Automation.Parameter]
        public Boolean ResetAllParameters { get; set; }
        
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
            
            var resourceIdentifiersText = FormatParameterValuesForConfirmationMsg("ParameterGroupName", MyInvocation.BoundParameters);
            if (!ConfirmShouldProceed(this.Force.IsPresent, resourceIdentifiersText, "Reset-RSClusterParameterGroup (ResetClusterParameterGroup)"))
            {
                return;
            }
            
            var context = new CmdletContext
            {
                Region = this.Region,
                Credentials = this.CurrentCredentials
            };
            
            context.ParameterGroupName = this.ParameterGroupName;
            if (this.Parameter != null)
            {
                context.Parameters = new List<Parameter>(this.Parameter);
            }
            if (ParameterWasBound("ResetAllParameters"))
                context.ResetAllParameters = this.ResetAllParameters;
            
            var output = Execute(context) as CmdletOutput;
            ProcessOutput(output);
        }
        
        #region IExecutor Members
        
        public object Execute(ExecutorContext context)
        {
            var cmdletContext = context as CmdletContext;
            // create request
            var request = new ResetClusterParameterGroupRequest();
            
            if (cmdletContext.ParameterGroupName != null)
            {
                request.ParameterGroupName = cmdletContext.ParameterGroupName;
            }
            if (cmdletContext.Parameters != null)
            {
                request.Parameters = cmdletContext.Parameters;
            }
            if (cmdletContext.ResetAllParameters != null)
            {
                request.ResetAllParameters = cmdletContext.ResetAllParameters.Value;
            }
            
            CmdletOutput output;
            
            // issue call
            var client = Client ?? CreateClient(context.Credentials, context.Region);
            try
            {
                var response = client.ResetClusterParameterGroup(request);
                Dictionary<string, object> notes = null;
                object pipelineOutput = response;
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
            public String ParameterGroupName { get; set; }
            public List<Parameter> Parameters { get; set; }
            public Boolean? ResetAllParameters { get; set; }
        }
        
    }
}
