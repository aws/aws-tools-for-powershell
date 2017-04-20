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
using Amazon.EC2;
using Amazon.EC2.Model;

namespace Amazon.PowerShell.Cmdlets.EC2
{
    /// <summary>
    /// Set the instance affinity value for a specific stopped instance and modify the instance
    /// tenancy setting.
    /// 
    ///  
    /// <para>
    /// Instance affinity is disabled by default. When instance affinity is <code>host</code>
    /// and it is not associated with a specific Dedicated Host, the next time it is launched
    /// it will automatically be associated with the host it lands on. This relationship will
    /// persist if the instance is stopped/started, or rebooted.
    /// </para><para>
    /// You can modify the host ID associated with a stopped instance. If a stopped instance
    /// has a new host ID association, the instance will target that host when restarted.
    /// </para><para>
    /// You can modify the tenancy of a stopped instance with a tenancy of <code>host</code>
    /// or <code>dedicated</code>.
    /// </para><para>
    /// Affinity, hostID, and tenancy are not required parameters, but at least one of them
    /// must be specified in the request. Affinity and tenancy can be modified in the same
    /// request, but tenancy can only be modified on instances that are stopped.
    /// </para>
    /// </summary>
    [Cmdlet("Edit", "EC2InstancePlacement", SupportsShouldProcess = true, ConfirmImpact = ConfirmImpact.Medium)]
    [OutputType("System.Boolean")]
    [AWSCmdlet("Invokes the ModifyInstancePlacement operation against Amazon Elastic Compute Cloud.", Operation = new[] {"ModifyInstancePlacement"})]
    [AWSCmdletOutput("System.Boolean",
        "This cmdlet returns a Boolean object.",
        "The service call response (type Amazon.EC2.Model.ModifyInstancePlacementResponse) can also be referenced from properties attached to the cmdlet entry in the $AWSHistory stack."
    )]
    public partial class EditEC2InstancePlacementCmdlet : AmazonEC2ClientCmdlet, IExecutor
    {
        
        #region Parameter Affinity
        /// <summary>
        /// <para>
        /// <para>The new affinity setting for the instance.</para>
        /// </para>
        /// </summary>
        [System.Management.Automation.Parameter]
        [AWSConstantClassSource("Amazon.EC2.Affinity")]
        public Amazon.EC2.Affinity Affinity { get; set; }
        #endregion
        
        #region Parameter HostId
        /// <summary>
        /// <para>
        /// <para>The ID of the Dedicated Host that the instance will have affinity with.</para>
        /// </para>
        /// </summary>
        [System.Management.Automation.Parameter]
        public System.String HostId { get; set; }
        #endregion
        
        #region Parameter InstanceId
        /// <summary>
        /// <para>
        /// <para>The ID of the instance that you are modifying.</para>
        /// </para>
        /// </summary>
        [System.Management.Automation.Parameter(Position = 0, ValueFromPipelineByPropertyName = true, ValueFromPipeline = true)]
        public System.String InstanceId { get; set; }
        #endregion
        
        #region Parameter Tenancy
        /// <summary>
        /// <para>
        /// <para>The tenancy of the instance that you are modifying.</para>
        /// </para>
        /// </summary>
        [System.Management.Automation.Parameter]
        [AWSConstantClassSource("Amazon.EC2.HostTenancy")]
        public Amazon.EC2.HostTenancy Tenancy { get; set; }
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
            
            var resourceIdentifiersText = FormatParameterValuesForConfirmationMsg("InstanceId", MyInvocation.BoundParameters);
            if (!ConfirmShouldProceed(this.Force.IsPresent, resourceIdentifiersText, "Edit-EC2InstancePlacement (ModifyInstancePlacement)"))
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
            
            context.Affinity = this.Affinity;
            context.HostId = this.HostId;
            context.InstanceId = this.InstanceId;
            context.Tenancy = this.Tenancy;
            
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
            var request = new Amazon.EC2.Model.ModifyInstancePlacementRequest();
            
            if (cmdletContext.Affinity != null)
            {
                request.Affinity = cmdletContext.Affinity;
            }
            if (cmdletContext.HostId != null)
            {
                request.HostId = cmdletContext.HostId;
            }
            if (cmdletContext.InstanceId != null)
            {
                request.InstanceId = cmdletContext.InstanceId;
            }
            if (cmdletContext.Tenancy != null)
            {
                request.Tenancy = cmdletContext.Tenancy;
            }
            
            CmdletOutput output;
            
            // issue call
            var client = Client ?? CreateClient(context.Credentials, context.Region);
            try
            {
                var response = CallAWSServiceOperation(client, request);
                Dictionary<string, object> notes = null;
                object pipelineOutput = response.Return;
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
        
        private Amazon.EC2.Model.ModifyInstancePlacementResponse CallAWSServiceOperation(IAmazonEC2 client, Amazon.EC2.Model.ModifyInstancePlacementRequest request)
        {
            Utils.Common.WriteVerboseEndpointMessage(this, client.Config, "Amazon Elastic Compute Cloud", "ModifyInstancePlacement");
            #if DESKTOP
            return client.ModifyInstancePlacement(request);
            #elif CORECLR
            // todo: handle AggregateException and extract true service exception for rethrow
            var task = client.ModifyInstancePlacementAsync(request);
            return task.Result;
            #else
                    #error "Unknown build edition"
            #endif
        }
        
        #endregion
        
        internal class CmdletContext : ExecutorContext
        {
            public Amazon.EC2.Affinity Affinity { get; set; }
            public System.String HostId { get; set; }
            public System.String InstanceId { get; set; }
            public Amazon.EC2.HostTenancy Tenancy { get; set; }
        }
        
    }
}
