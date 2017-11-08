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
using Amazon.DirectConnect;
using Amazon.DirectConnect.Model;

namespace Amazon.PowerShell.Cmdlets.DC
{
    /// <summary>
    /// Updates the attributes of a link aggregation group (LAG). 
    /// 
    ///  
    /// <para>
    /// You can update the following attributes: 
    /// </para><ul><li><para>
    /// The name of the LAG.
    /// </para></li><li><para>
    /// The value for the minimum number of connections that must be operational for the LAG
    /// itself to be operational. 
    /// </para></li></ul><para>
    /// When you create a LAG, the default value for the minimum number of operational connections
    /// is zero (0). If you update this value, and the number of operational connections falls
    /// below the specified value, the LAG will automatically go down to avoid overutilization
    /// of the remaining connections. Adjusting this value should be done with care as it
    /// could force the LAG down if the value is set higher than the current number of operational
    /// connections.
    /// </para>
    /// </summary>
    [Cmdlet("Update", "DCLag", SupportsShouldProcess = true, ConfirmImpact = ConfirmImpact.Medium)]
    [OutputType("Amazon.DirectConnect.Model.UpdateLagResponse")]
    [AWSCmdlet("Calls the AWS Direct Connect UpdateLag API operation.", Operation = new[] {"UpdateLag"})]
    [AWSCmdletOutput("Amazon.DirectConnect.Model.UpdateLagResponse",
        "This cmdlet returns a Amazon.DirectConnect.Model.UpdateLagResponse object containing multiple properties. The object can also be referenced from properties attached to the cmdlet entry in the $AWSHistory stack."
    )]
    public partial class UpdateDCLagCmdlet : AmazonDirectConnectClientCmdlet, IExecutor
    {
        
        #region Parameter LagId
        /// <summary>
        /// <para>
        /// <para>The ID of the LAG to update.</para><para>Example: dxlag-abc123</para><para>Default: None</para>
        /// </para>
        /// </summary>
        [System.Management.Automation.Parameter(Position = 0, ValueFromPipeline = true)]
        public System.String LagId { get; set; }
        #endregion
        
        #region Parameter LagName
        /// <summary>
        /// <para>
        /// <para>The name for the LAG.</para><para>Example: "<code>3x10G LAG to AWS</code>"</para><para>Default: None</para>
        /// </para>
        /// </summary>
        [System.Management.Automation.Parameter]
        public System.String LagName { get; set; }
        #endregion
        
        #region Parameter MinimumLink
        /// <summary>
        /// <para>
        /// <para>The minimum number of physical connections that must be operational for the LAG itself
        /// to be operational.</para><para>Default: None</para>
        /// </para>
        /// </summary>
        [System.Management.Automation.Parameter]
        [Alias("MinimumLinks")]
        public System.Int32 MinimumLink { get; set; }
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
            
            var resourceIdentifiersText = FormatParameterValuesForConfirmationMsg("LagId", MyInvocation.BoundParameters);
            if (!ConfirmShouldProceed(this.Force.IsPresent, resourceIdentifiersText, "Update-DCLag (UpdateLag)"))
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
            
            context.LagId = this.LagId;
            context.LagName = this.LagName;
            if (ParameterWasBound("MinimumLink"))
                context.MinimumLinks = this.MinimumLink;
            
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
            var request = new Amazon.DirectConnect.Model.UpdateLagRequest();
            
            if (cmdletContext.LagId != null)
            {
                request.LagId = cmdletContext.LagId;
            }
            if (cmdletContext.LagName != null)
            {
                request.LagName = cmdletContext.LagName;
            }
            if (cmdletContext.MinimumLinks != null)
            {
                request.MinimumLinks = cmdletContext.MinimumLinks.Value;
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
        
        private Amazon.DirectConnect.Model.UpdateLagResponse CallAWSServiceOperation(IAmazonDirectConnect client, Amazon.DirectConnect.Model.UpdateLagRequest request)
        {
            Utils.Common.WriteVerboseEndpointMessage(this, client.Config, "AWS Direct Connect", "UpdateLag");
            try
            {
                #if DESKTOP
                return client.UpdateLag(request);
                #elif CORECLR
                // todo: handle AggregateException and extract true service exception for rethrow
                var task = client.UpdateLagAsync(request);
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
            public System.String LagId { get; set; }
            public System.String LagName { get; set; }
            public System.Int32? MinimumLinks { get; set; }
        }
        
    }
}
