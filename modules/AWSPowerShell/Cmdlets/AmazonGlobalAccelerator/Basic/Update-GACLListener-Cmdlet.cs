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
using Amazon.GlobalAccelerator;
using Amazon.GlobalAccelerator.Model;

namespace Amazon.PowerShell.Cmdlets.GACL
{
    /// <summary>
    /// Update a listener.
    /// </summary>
    [Cmdlet("Update", "GACLListener", SupportsShouldProcess = true, ConfirmImpact = ConfirmImpact.Medium)]
    [OutputType("Amazon.GlobalAccelerator.Model.Listener")]
    [AWSCmdlet("Calls the AWS Global Accelerator UpdateListener API operation.", Operation = new[] {"UpdateListener"})]
    [AWSCmdletOutput("Amazon.GlobalAccelerator.Model.Listener",
        "This cmdlet returns a Listener object.",
        "The service call response (type Amazon.GlobalAccelerator.Model.UpdateListenerResponse) can also be referenced from properties attached to the cmdlet entry in the $AWSHistory stack."
    )]
    public partial class UpdateGACLListenerCmdlet : AmazonGlobalAcceleratorClientCmdlet, IExecutor
    {
        
        #region Parameter ClientAffinity
        /// <summary>
        /// <para>
        /// <para>Client affinity lets you direct all requests from a user to the same endpoint, if
        /// you have stateful applications, regardless of the source port and protocol of the
        /// user request. This gives you control over whether and how to maintain client affinity
        /// to a given endpoint.</para><para>The default value is <code>NONE</code>.</para>
        /// </para>
        /// </summary>
        [System.Management.Automation.Parameter]
        [AWSConstantClassSource("Amazon.GlobalAccelerator.ClientAffinity")]
        public Amazon.GlobalAccelerator.ClientAffinity ClientAffinity { get; set; }
        #endregion
        
        #region Parameter ListenerArn
        /// <summary>
        /// <para>
        /// <para>The Amazon Resource Name (ARN) of the listener to update.</para>
        /// </para>
        /// </summary>
        [System.Management.Automation.Parameter(Position = 0, ValueFromPipelineByPropertyName = true, ValueFromPipeline = true)]
        public System.String ListenerArn { get; set; }
        #endregion
        
        #region Parameter PortRange
        /// <summary>
        /// <para>
        /// <para>The updated list of port ranges for the connections from clients to the accelerator.</para>
        /// </para>
        /// </summary>
        [System.Management.Automation.Parameter]
        [Alias("PortRanges")]
        public Amazon.GlobalAccelerator.Model.PortRange[] PortRange { get; set; }
        #endregion
        
        #region Parameter Protocol
        /// <summary>
        /// <para>
        /// <para>The updated protocol for the connections from clients to the accelerator.</para>
        /// </para>
        /// </summary>
        [System.Management.Automation.Parameter]
        [AWSConstantClassSource("Amazon.GlobalAccelerator.Protocol")]
        public Amazon.GlobalAccelerator.Protocol Protocol { get; set; }
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
            
            var resourceIdentifiersText = FormatParameterValuesForConfirmationMsg("ListenerArn", MyInvocation.BoundParameters);
            if (!ConfirmShouldProceed(this.Force.IsPresent, resourceIdentifiersText, "Update-GACLListener (UpdateListener)"))
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
            
            context.ClientAffinity = this.ClientAffinity;
            context.ListenerArn = this.ListenerArn;
            if (this.PortRange != null)
            {
                context.PortRanges = new List<Amazon.GlobalAccelerator.Model.PortRange>(this.PortRange);
            }
            context.Protocol = this.Protocol;
            
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
            var request = new Amazon.GlobalAccelerator.Model.UpdateListenerRequest();
            
            if (cmdletContext.ClientAffinity != null)
            {
                request.ClientAffinity = cmdletContext.ClientAffinity;
            }
            if (cmdletContext.ListenerArn != null)
            {
                request.ListenerArn = cmdletContext.ListenerArn;
            }
            if (cmdletContext.PortRanges != null)
            {
                request.PortRanges = cmdletContext.PortRanges;
            }
            if (cmdletContext.Protocol != null)
            {
                request.Protocol = cmdletContext.Protocol;
            }
            
            CmdletOutput output;
            
            // issue call
            var client = Client ?? CreateClient(context.Credentials, context.Region);
            try
            {
                var response = CallAWSServiceOperation(client, request);
                Dictionary<string, object> notes = null;
                object pipelineOutput = response.Listener;
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
        
        private Amazon.GlobalAccelerator.Model.UpdateListenerResponse CallAWSServiceOperation(IAmazonGlobalAccelerator client, Amazon.GlobalAccelerator.Model.UpdateListenerRequest request)
        {
            Utils.Common.WriteVerboseEndpointMessage(this, client.Config, "AWS Global Accelerator", "UpdateListener");
            try
            {
                #if DESKTOP
                return client.UpdateListener(request);
                #elif CORECLR
                // todo: handle AggregateException and extract true service exception for rethrow
                var task = client.UpdateListenerAsync(request);
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
            public Amazon.GlobalAccelerator.ClientAffinity ClientAffinity { get; set; }
            public System.String ListenerArn { get; set; }
            public List<Amazon.GlobalAccelerator.Model.PortRange> PortRanges { get; set; }
            public Amazon.GlobalAccelerator.Protocol Protocol { get; set; }
        }
        
    }
}
