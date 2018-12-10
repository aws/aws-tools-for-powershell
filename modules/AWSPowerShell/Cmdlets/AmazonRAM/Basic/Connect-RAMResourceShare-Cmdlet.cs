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
using Amazon.RAM;
using Amazon.RAM.Model;

namespace Amazon.PowerShell.Cmdlets.RAM
{
    /// <summary>
    /// Associates the specified resource share with the specified principals and resources.
    /// </summary>
    [Cmdlet("Connect", "RAMResourceShare", SupportsShouldProcess = true, ConfirmImpact = ConfirmImpact.Medium)]
    [OutputType("Amazon.RAM.Model.ResourceShareAssociation")]
    [AWSCmdlet("Calls the AWS Resource Access Manager AssociateResourceShare API operation.", Operation = new[] {"AssociateResourceShare"})]
    [AWSCmdletOutput("Amazon.RAM.Model.ResourceShareAssociation",
        "This cmdlet returns a collection of ResourceShareAssociation objects.",
        "The service call response (type Amazon.RAM.Model.AssociateResourceShareResponse) can also be referenced from properties attached to the cmdlet entry in the $AWSHistory stack.",
        "Additionally, the following properties are added as Note properties to the service response type instance for the cmdlet entry in the $AWSHistory stack: ClientToken (type System.String)"
    )]
    public partial class ConnectRAMResourceShareCmdlet : AmazonRAMClientCmdlet, IExecutor
    {
        
        #region Parameter Principal
        /// <summary>
        /// <para>
        /// <para>The principals.</para>
        /// </para>
        /// </summary>
        [System.Management.Automation.Parameter]
        [Alias("Principals")]
        public System.String[] Principal { get; set; }
        #endregion
        
        #region Parameter ResourceArn
        /// <summary>
        /// <para>
        /// <para>The Amazon Resource Names (ARN) of the resources.</para>
        /// </para>
        /// </summary>
        [System.Management.Automation.Parameter]
        [Alias("ResourceArns")]
        public System.String[] ResourceArn { get; set; }
        #endregion
        
        #region Parameter ResourceShareArn
        /// <summary>
        /// <para>
        /// <para>The Amazon Resource Name (ARN) of the resource share.</para>
        /// </para>
        /// </summary>
        [System.Management.Automation.Parameter(Position = 0, ValueFromPipeline = true)]
        public System.String ResourceShareArn { get; set; }
        #endregion
        
        #region Parameter ClientToken
        /// <summary>
        /// <para>
        /// <para>A unique, case-sensitive identifier that you provide to ensure the idempotency of
        /// the request.</para>
        /// </para>
        /// </summary>
        [System.Management.Automation.Parameter]
        public System.String ClientToken { get; set; }
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
            
            var resourceIdentifiersText = FormatParameterValuesForConfirmationMsg("ResourceShareArn", MyInvocation.BoundParameters);
            if (!ConfirmShouldProceed(this.Force.IsPresent, resourceIdentifiersText, "Connect-RAMResourceShare (AssociateResourceShare)"))
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
            
            context.ClientToken = this.ClientToken;
            if (this.Principal != null)
            {
                context.Principals = new List<System.String>(this.Principal);
            }
            if (this.ResourceArn != null)
            {
                context.ResourceArns = new List<System.String>(this.ResourceArn);
            }
            context.ResourceShareArn = this.ResourceShareArn;
            
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
            var request = new Amazon.RAM.Model.AssociateResourceShareRequest();
            
            if (cmdletContext.ClientToken != null)
            {
                request.ClientToken = cmdletContext.ClientToken;
            }
            if (cmdletContext.Principals != null)
            {
                request.Principals = cmdletContext.Principals;
            }
            if (cmdletContext.ResourceArns != null)
            {
                request.ResourceArns = cmdletContext.ResourceArns;
            }
            if (cmdletContext.ResourceShareArn != null)
            {
                request.ResourceShareArn = cmdletContext.ResourceShareArn;
            }
            
            CmdletOutput output;
            
            // issue call
            var client = Client ?? CreateClient(context.Credentials, context.Region);
            try
            {
                var response = CallAWSServiceOperation(client, request);
                Dictionary<string, object> notes = null;
                object pipelineOutput = response.ResourceShareAssociations;
                notes = new Dictionary<string, object>();
                notes["ClientToken"] = response.ClientToken;
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
        
        private Amazon.RAM.Model.AssociateResourceShareResponse CallAWSServiceOperation(IAmazonRAM client, Amazon.RAM.Model.AssociateResourceShareRequest request)
        {
            Utils.Common.WriteVerboseEndpointMessage(this, client.Config, "AWS Resource Access Manager", "AssociateResourceShare");
            try
            {
                #if DESKTOP
                return client.AssociateResourceShare(request);
                #elif CORECLR
                // todo: handle AggregateException and extract true service exception for rethrow
                var task = client.AssociateResourceShareAsync(request);
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
            public System.String ClientToken { get; set; }
            public List<System.String> Principals { get; set; }
            public List<System.String> ResourceArns { get; set; }
            public System.String ResourceShareArn { get; set; }
        }
        
    }
}
