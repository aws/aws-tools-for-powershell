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
using Amazon.ElasticMapReduce;
using Amazon.ElasticMapReduce.Model;

namespace Amazon.PowerShell.Cmdlets.EMR
{
    /// <summary>
    /// ModifyInstanceGroups modifies the number of nodes and configuration settings of an
    /// instance group. The input parameters include the new target instance count for the
    /// group and the instance group ID. The call will either succeed or fail atomically.
    /// </summary>
    [Cmdlet("Edit", "EMRInstanceGroup", SupportsShouldProcess = true, ConfirmImpact = ConfirmImpact.Medium)]
    [OutputType("None","Amazon.ElasticMapReduce.Model.InstanceGroupModifyConfig")]
    [AWSCmdlet("Invokes the ModifyInstanceGroups operation against Amazon Elastic MapReduce.", Operation = new[] {"ModifyInstanceGroups"})]
    [AWSCmdletOutput("None or Amazon.ElasticMapReduce.Model.InstanceGroupModifyConfig",
        "When you use the PassThru parameter, this cmdlet outputs the value supplied to the InstanceGroup parameter. Otherwise, this cmdlet does not return any output. " +
        "The service response (type Amazon.ElasticMapReduce.Model.ModifyInstanceGroupsResponse) can be referenced from properties attached to the cmdlet entry in the $AWSHistory stack."
    )]
    public class EditEMRInstanceGroupCmdlet : AmazonElasticMapReduceClientCmdlet, IExecutor
    {
        /// <summary>
        /// <para>
        /// <para>Instance groups to change.</para>
        /// </para>
        /// </summary>
        [System.Management.Automation.Parameter(Position = 0, ValueFromPipeline = true)]
        [Alias("InstanceGroups")]
        public Amazon.ElasticMapReduce.Model.InstanceGroupModifyConfig[] InstanceGroup { get; set; }
        
        /// <summary>
        /// Returns the value passed to the InstanceGroup parameter.
        /// By default, this cmdlet does not generate any output.
        /// </summary>
        [System.Management.Automation.Parameter]
        public SwitchParameter PassThru { get; set; }
        
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
            
            var resourceIdentifiersText = FormatParameterValuesForConfirmationMsg("InstanceGroup", MyInvocation.BoundParameters);
            if (!ConfirmShouldProceed(this.Force.IsPresent, resourceIdentifiersText, "Edit-EMRInstanceGroup (ModifyInstanceGroups)"))
            {
                return;
            }
            
            var context = new CmdletContext
            {
                Region = this.Region,
                Credentials = this.CurrentCredentials
            };
            
            if (this.InstanceGroup != null)
            {
                context.InstanceGroups = new List<Amazon.ElasticMapReduce.Model.InstanceGroupModifyConfig>(this.InstanceGroup);
            }
            
            var output = Execute(context) as CmdletOutput;
            ProcessOutput(output);
        }
        
        #region IExecutor Members
        
        public object Execute(ExecutorContext context)
        {
            var cmdletContext = context as CmdletContext;
            // create request
            var request = new Amazon.ElasticMapReduce.Model.ModifyInstanceGroupsRequest();
            
            if (cmdletContext.InstanceGroups != null)
            {
                request.InstanceGroups = cmdletContext.InstanceGroups;
            }
            
            CmdletOutput output;
            
            // issue call
            var client = Client ?? CreateClient(context.Credentials, context.Region);
            try
            {
                var response = client.ModifyInstanceGroups(request);
                Dictionary<string, object> notes = null;
                object pipelineOutput = null;
                if (this.PassThru.IsPresent)
                    pipelineOutput = this.InstanceGroup;
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
            public List<Amazon.ElasticMapReduce.Model.InstanceGroupModifyConfig> InstanceGroups { get; set; }
        }
        
    }
}
