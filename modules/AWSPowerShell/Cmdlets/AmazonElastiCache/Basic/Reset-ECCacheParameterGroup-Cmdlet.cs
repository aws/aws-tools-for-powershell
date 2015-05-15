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
using Amazon.ElastiCache;
using Amazon.ElastiCache.Model;

namespace Amazon.PowerShell.Cmdlets.EC
{
    /// <summary>
    /// The <i>ResetCacheParameterGroup</i> action modifies the parameters of a cache parameter
    /// group to the engine or system default value. You can reset specific parameters by
    /// submitting a list of parameter names. To reset the entire cache parameter group, specify
    /// the <i>ResetAllParameters</i> and <i>CacheParameterGroupName</i> parameters.
    /// </summary>
    [Cmdlet("Reset", "ECCacheParameterGroup", SupportsShouldProcess = true, ConfirmImpact = ConfirmImpact.Medium)]
    [OutputType("System.String")]
    [AWSCmdlet("Invokes the ResetCacheParameterGroup operation against Amazon ElastiCache.", Operation = new[] {"ResetCacheParameterGroup"})]
    [AWSCmdletOutput("System.String",
        "This cmdlet returns a String object.",
        "The service call response (type ResetCacheParameterGroupResponse) can also be referenced from properties attached to the cmdlet entry in the $AWSHistory stack."
    )]
    public class ResetECCacheParameterGroupCmdlet : AmazonElastiCacheClientCmdlet, IExecutor
    {
        /// <summary>
        /// <para>
        /// <para>The name of the cache parameter group to reset.</para>
        /// </para>
        /// </summary>
        [System.Management.Automation.Parameter(Position = 0, ValueFromPipelineByPropertyName = true, ValueFromPipeline = true)]
        public String CacheParameterGroupName { get; set; }
        
        /// <summary>
        /// <para>
        /// <para>An array of parameter names to be reset. If you are not resetting the entire cache
        /// parameter group, you must specify at least one parameter name.</para>
        /// </para>
        /// </summary>
        [System.Management.Automation.Parameter]
        [Alias("ParameterNameValues")]
        public Amazon.ElastiCache.Model.ParameterNameValue[] ParameterNameValue { get; set; }
        
        /// <summary>
        /// <para>
        /// <para>If <i>true</i>, all parameters in the cache parameter group will be reset to default
        /// values. If <i>false</i>, no such action occurs.</para><para>Valid values: <code>true</code> | <code>false</code></para>
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
            
            var resourceIdentifiersText = FormatParameterValuesForConfirmationMsg("CacheParameterGroupName", MyInvocation.BoundParameters);
            if (!ConfirmShouldProceed(this.Force.IsPresent, resourceIdentifiersText, "Reset-ECCacheParameterGroup (ResetCacheParameterGroup)"))
            {
                return;
            }
            
            var context = new CmdletContext
            {
                Region = this.Region,
                Credentials = this.CurrentCredentials
            };
            
            context.CacheParameterGroupName = this.CacheParameterGroupName;
            if (this.ParameterNameValue != null)
            {
                context.ParameterNameValues = new List<ParameterNameValue>(this.ParameterNameValue);
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
            var request = new ResetCacheParameterGroupRequest();
            
            if (cmdletContext.CacheParameterGroupName != null)
            {
                request.CacheParameterGroupName = cmdletContext.CacheParameterGroupName;
            }
            if (cmdletContext.ParameterNameValues != null)
            {
                request.ParameterNameValues = cmdletContext.ParameterNameValues;
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
                var response = client.ResetCacheParameterGroup(request);
                Dictionary<string, object> notes = null;
                object pipelineOutput = response.CacheParameterGroupName;
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
            public String CacheParameterGroupName { get; set; }
            public List<ParameterNameValue> ParameterNameValues { get; set; }
            public Boolean? ResetAllParameters { get; set; }
        }
        
    }
}
