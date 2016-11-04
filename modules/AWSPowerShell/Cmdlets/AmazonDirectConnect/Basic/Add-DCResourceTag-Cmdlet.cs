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
    /// Adds the specified tags to the specified Direct Connect resource. Each Direct Connect
    /// resource can have a maximum of 50 tags.
    /// 
    ///  
    /// <para>
    /// Each tag consists of a key and an optional value. If a tag with the same key is already
    /// associated with the Direct Connect resource, this action updates its value.
    /// </para>
    /// </summary>
    [Cmdlet("Add", "DCResourceTag", SupportsShouldProcess = true, ConfirmImpact = ConfirmImpact.Medium)]
    [OutputType("None")]
    [AWSCmdlet("Invokes the TagResource operation against AWS Direct Connect.", Operation = new[] {"TagResource"})]
    [AWSCmdletOutput("None",
        "This cmdlet does not generate any output. " +
        "The service response (type Amazon.DirectConnect.Model.TagResourceResponse) can be referenced from properties attached to the cmdlet entry in the $AWSHistory stack."
    )]
    public partial class AddDCResourceTagCmdlet : AmazonDirectConnectClientCmdlet, IExecutor
    {
        
        #region Parameter ResourceArn
        /// <summary>
        /// <para>
        /// <para>The Amazon Resource Name (ARN) of the Direct Connect resource.</para><para>Example: arn:aws:directconnect:us-east-1:123456789012:dxcon/dxcon-fg5678gh</para>
        /// </para>
        /// </summary>
        [System.Management.Automation.Parameter]
        public System.String ResourceArn { get; set; }
        #endregion
        
        #region Parameter Tag
        /// <summary>
        /// <para>
        /// <para>The list of tags to add.</para>
        /// </para>
        /// </summary>
        [System.Management.Automation.Parameter]
        [Alias("Tags")]
        public Amazon.DirectConnect.Model.Tag[] Tag { get; set; }
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
            
            var resourceIdentifiersText = FormatParameterValuesForConfirmationMsg("ResourceArn", MyInvocation.BoundParameters);
            if (!ConfirmShouldProceed(this.Force.IsPresent, resourceIdentifiersText, "Add-DCResourceTag (TagResource)"))
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
            
            context.ResourceArn = this.ResourceArn;
            if (this.Tag != null)
            {
                context.Tags = new List<Amazon.DirectConnect.Model.Tag>(this.Tag);
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
            var request = new Amazon.DirectConnect.Model.TagResourceRequest();
            
            if (cmdletContext.ResourceArn != null)
            {
                request.ResourceArn = cmdletContext.ResourceArn;
            }
            if (cmdletContext.Tags != null)
            {
                request.Tags = cmdletContext.Tags;
            }
            
            CmdletOutput output;
            
            // issue call
            var client = Client ?? CreateClient(context.Credentials, context.Region);
            try
            {
                var response = CallAWSServiceOperation(client, request);
                Dictionary<string, object> notes = null;
                object pipelineOutput = null;
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
        
        private static Amazon.DirectConnect.Model.TagResourceResponse CallAWSServiceOperation(IAmazonDirectConnect client, Amazon.DirectConnect.Model.TagResourceRequest request)
        {
            #if DESKTOP
            return client.TagResource(request);
            #elif CORECLR
            // todo: handle AggregateException and extract true service exception for rethrow
            var task = client.TagResourceAsync(request);
            return task.Result;
            #else
                    #error "Unknown build edition"
            #endif
        }
        
        #endregion
        
        internal class CmdletContext : ExecutorContext
        {
            public System.String ResourceArn { get; set; }
            public List<Amazon.DirectConnect.Model.Tag> Tags { get; set; }
        }
        
    }
}
