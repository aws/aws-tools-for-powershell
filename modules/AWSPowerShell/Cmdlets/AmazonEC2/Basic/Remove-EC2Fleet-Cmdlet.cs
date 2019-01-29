/*******************************************************************************
 *  Copyright 2012-2018 Amazon.com, Inc. or its affiliates. All Rights Reserved.
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
    /// Deletes the specified EC2 Fleet.
    /// 
    ///  
    /// <para>
    /// After you delete an EC2 Fleet, it launches no new instances. You must specify whether
    /// an EC2 Fleet should also terminate its instances. If you terminate the instances,
    /// the EC2 Fleet enters the <code>deleted_terminating</code> state. Otherwise, the EC2
    /// Fleet enters the <code>deleted_running</code> state, and the instances continue to
    /// run until they are interrupted or you terminate them manually. 
    /// </para>
    /// </summary>
    [Cmdlet("Remove", "EC2Fleet", SupportsShouldProcess = true, ConfirmImpact = ConfirmImpact.High)]
    [OutputType("Amazon.EC2.Model.DeleteFleetsResponse")]
    [AWSCmdlet("Calls the Amazon Elastic Compute Cloud DeleteFleets API operation.", Operation = new[] {"DeleteFleets"})]
    [AWSCmdletOutput("Amazon.EC2.Model.DeleteFleetsResponse",
        "This cmdlet returns a Amazon.EC2.Model.DeleteFleetsResponse object containing multiple properties. The object can also be referenced from properties attached to the cmdlet entry in the $AWSHistory stack."
    )]
    public partial class RemoveEC2FleetCmdlet : AmazonEC2ClientCmdlet, IExecutor
    {
        
        #region Parameter FleetId
        /// <summary>
        /// <para>
        /// <para>The IDs of the EC2 Fleets.</para>
        /// </para>
        /// </summary>
        [System.Management.Automation.Parameter(Position = 0, ValueFromPipeline = true)]
        [Alias("FleetIds")]
        public System.String[] FleetId { get; set; }
        #endregion
        
        #region Parameter TerminateInstance
        /// <summary>
        /// <para>
        /// <para>Indicates whether to terminate instances for an EC2 Fleet if it is deleted successfully.</para>
        /// </para>
        /// </summary>
        [System.Management.Automation.Parameter]
        [Alias("TerminateInstances")]
        public System.Boolean TerminateInstance { get; set; }
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
            
            var resourceIdentifiersText = FormatParameterValuesForConfirmationMsg("FleetId", MyInvocation.BoundParameters);
            if (!ConfirmShouldProceed(this.Force.IsPresent, resourceIdentifiersText, "Remove-EC2Fleet (DeleteFleets)"))
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
            
            if (this.FleetId != null)
            {
                context.FleetIds = new List<System.String>(this.FleetId);
            }
            if (ParameterWasBound("TerminateInstance"))
                context.TerminateInstances = this.TerminateInstance;
            
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
            var request = new Amazon.EC2.Model.DeleteFleetsRequest();
            
            if (cmdletContext.FleetIds != null)
            {
                request.FleetIds = cmdletContext.FleetIds;
            }
            if (cmdletContext.TerminateInstances != null)
            {
                request.TerminateInstances = cmdletContext.TerminateInstances.Value;
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
        
        private Amazon.EC2.Model.DeleteFleetsResponse CallAWSServiceOperation(IAmazonEC2 client, Amazon.EC2.Model.DeleteFleetsRequest request)
        {
            Utils.Common.WriteVerboseEndpointMessage(this, client.Config, "Amazon Elastic Compute Cloud", "DeleteFleets");
            try
            {
                #if DESKTOP
                return client.DeleteFleets(request);
                #elif CORECLR
                // todo: handle AggregateException and extract true service exception for rethrow
                var task = client.DeleteFleetsAsync(request);
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
            public List<System.String> FleetIds { get; set; }
            public System.Boolean? TerminateInstances { get; set; }
        }
        
    }
}
