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
    /// When you no longer want to use an On-Demand Dedicated Host it can be released. On-Demand
    /// billing is stopped and the host goes into <code>released</code> state. The host ID
    /// of Dedicated Hosts that have been released can no longer be specified in another request,
    /// e.g., ModifyHosts. You must stop or terminate all instances on a host before it can
    /// be released.
    /// 
    ///  
    /// <para>
    /// When Dedicated Hosts are released, it make take some time for them to stop counting
    /// toward your limit and you may receive capacity errors when trying to allocate new
    /// Dedicated hosts. Try waiting a few minutes, and then try again.
    /// </para><para>
    /// Released hosts will still appear in a <a>DescribeHosts</a> response.
    /// </para>
    /// </summary>
    [Cmdlet("Remove", "EC2Host", SupportsShouldProcess = true, ConfirmImpact = ConfirmImpact.High)]
    [OutputType("Amazon.EC2.Model.ReleaseHostsResponse")]
    [AWSCmdlet("Invokes the ReleaseHosts operation against Amazon Elastic Compute Cloud.", Operation = new[] {"ReleaseHosts"}, LegacyAlias="ReleaseHosts")]
    [AWSCmdletOutput("Amazon.EC2.Model.ReleaseHostsResponse",
        "This cmdlet returns a Amazon.EC2.Model.ReleaseHostsResponse object containing multiple properties. The object can also be referenced from properties attached to the cmdlet entry in the $AWSHistory stack."
    )]
    public partial class RemoveEC2HostCmdlet : AmazonEC2ClientCmdlet, IExecutor
    {
        
        #region Parameter HostId
        /// <summary>
        /// <para>
        /// <para>The IDs of the Dedicated Hosts you want to release.</para>
        /// </para>
        /// </summary>
        [System.Management.Automation.Parameter(Position = 0, ValueFromPipeline = true)]
        [Alias("HostIds")]
        public System.String[] HostId { get; set; }
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
            
            var resourceIdentifiersText = FormatParameterValuesForConfirmationMsg("HostId", MyInvocation.BoundParameters);
            if (!ConfirmShouldProceed(this.Force.IsPresent, resourceIdentifiersText, "Remove-EC2Host (ReleaseHosts)"))
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
            
            if (this.HostId != null)
            {
                context.HostIds = new List<System.String>(this.HostId);
            }
            
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
            var request = new Amazon.EC2.Model.ReleaseHostsRequest();
            
            if (cmdletContext.HostIds != null)
            {
                request.HostIds = cmdletContext.HostIds;
            }
            
            CmdletOutput output;
            
            // issue call
            var client = Client ?? CreateClient(context.Credentials, context.Region);
            try
            {
                var response = CallAWSServiceOperation(client, request);
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
        
        #region AWS Service Operation Call
        
        private Amazon.EC2.Model.ReleaseHostsResponse CallAWSServiceOperation(IAmazonEC2 client, Amazon.EC2.Model.ReleaseHostsRequest request)
        {
            Utils.Common.WriteVerboseEndpointMessage(this, client.Config, "Amazon Elastic Compute Cloud", "ReleaseHosts");
            try
            {
                #if DESKTOP
                return client.ReleaseHosts(request);
                #elif CORECLR
                // todo: handle AggregateException and extract true service exception for rethrow
                var task = client.ReleaseHostsAsync(request);
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
            public List<System.String> HostIds { get; set; }
        }
        
    }
}
