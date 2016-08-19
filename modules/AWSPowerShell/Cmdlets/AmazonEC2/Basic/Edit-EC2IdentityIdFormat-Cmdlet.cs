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
    /// Modifies the ID format of a resource for the specified IAM user, IAM role, or root
    /// user. You can specify that resources should receive longer IDs (17-character IDs)
    /// when they are created. The following resource types support longer IDs: <code>instance</code>
    /// | <code>reservation</code> | <code>snapshot</code> | <code>volume</code>. For more
    /// information, see <a href="http://docs.aws.amazon.com/AWSEC2/latest/UserGuide/resource-ids.html">Resource
    /// IDs</a> in the <i>Amazon Elastic Compute Cloud User Guide</i>. 
    /// 
    ///  
    /// <para>
    /// This setting applies to the principal specified in the request; it does not apply
    /// to the principal that makes the request. 
    /// </para><para>
    /// Resources created with longer IDs are visible to all IAM roles and users, regardless
    /// of these settings and provided that they have permission to use the relevant <code>Describe</code>
    /// command for the resource type.
    /// </para>
    /// </summary>
    [Cmdlet("Edit", "EC2IdentityIdFormat", SupportsShouldProcess = true, ConfirmImpact = ConfirmImpact.Medium)]
    [OutputType("None","System.String")]
    [AWSCmdlet("Invokes the ModifyIdentityIdFormat operation against Amazon Elastic Compute Cloud.", Operation = new[] {"ModifyIdentityIdFormat"})]
    [AWSCmdletOutput("None or System.String",
        "When you use the PassThru parameter, this cmdlet outputs the value supplied to the PrincipalArn parameter. Otherwise, this cmdlet does not return any output. " +
        "The service response (type Amazon.EC2.Model.ModifyIdentityIdFormatResponse) can be referenced from properties attached to the cmdlet entry in the $AWSHistory stack."
    )]
    public partial class EditEC2IdentityIdFormatCmdlet : AmazonEC2ClientCmdlet, IExecutor
    {
        
        #region Parameter PrincipalArn
        /// <summary>
        /// <para>
        /// <para>The ARN of the principal, which can be an IAM user, IAM role, or the root user.</para>
        /// </para>
        /// </summary>
        [System.Management.Automation.Parameter(Position = 0, ValueFromPipeline = true)]
        public System.String PrincipalArn { get; set; }
        #endregion
        
        #region Parameter Resource
        /// <summary>
        /// <para>
        /// <para>The type of resource: <code>instance</code> | <code>reservation</code> | <code>snapshot</code>
        /// | <code>volume</code></para>
        /// </para>
        /// </summary>
        [System.Management.Automation.Parameter(Position = 1)]
        public System.String Resource { get; set; }
        #endregion
        
        #region Parameter UseLongId
        /// <summary>
        /// <para>
        /// <para>Indicates whether the resource should use longer IDs (17-character IDs)</para>
        /// </para>
        /// </summary>
        [System.Management.Automation.Parameter]
        [Alias("UseLongIds")]
        public System.Boolean UseLongId { get; set; }
        #endregion
        
        #region Parameter PassThru
        /// <summary>
        /// Returns the value passed to the PrincipalArn parameter.
        /// By default, this cmdlet does not generate any output.
        /// </summary>
        [System.Management.Automation.Parameter]
        public SwitchParameter PassThru { get; set; }
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
            
            var resourceIdentifiersText = FormatParameterValuesForConfirmationMsg("PrincipalArn", MyInvocation.BoundParameters);
            if (!ConfirmShouldProceed(this.Force.IsPresent, resourceIdentifiersText, "Edit-EC2IdentityIdFormat (ModifyIdentityIdFormat)"))
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
            
            context.PrincipalArn = this.PrincipalArn;
            context.Resource = this.Resource;
            if (ParameterWasBound("UseLongId"))
                context.UseLongIds = this.UseLongId;
            
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
            var request = new Amazon.EC2.Model.ModifyIdentityIdFormatRequest();
            
            if (cmdletContext.PrincipalArn != null)
            {
                request.PrincipalArn = cmdletContext.PrincipalArn;
            }
            if (cmdletContext.Resource != null)
            {
                request.Resource = cmdletContext.Resource;
            }
            if (cmdletContext.UseLongIds != null)
            {
                request.UseLongIds = cmdletContext.UseLongIds.Value;
            }
            
            CmdletOutput output;
            
            // issue call
            var client = Client ?? CreateClient(context.Credentials, context.Region);
            try
            {
                var response = CallAWSServiceOperation(client, request);
                Dictionary<string, object> notes = null;
                object pipelineOutput = null;
                if (this.PassThru.IsPresent)
                    pipelineOutput = this.PrincipalArn;
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
        
        private static Amazon.EC2.Model.ModifyIdentityIdFormatResponse CallAWSServiceOperation(IAmazonEC2 client, Amazon.EC2.Model.ModifyIdentityIdFormatRequest request)
        {
            #if DESKTOP
            return client.ModifyIdentityIdFormat(request);
            #elif CORECLR
            // todo: handle AggregateException and extract true service exception for rethrow
            var task = client.ModifyIdentityIdFormatAsync(request);
            return task.Result;
            #else
                    #error "Unknown build edition"
            #endif
        }
        
        #endregion
        
        internal class CmdletContext : ExecutorContext
        {
            public System.String PrincipalArn { get; set; }
            public System.String Resource { get; set; }
            public System.Boolean? UseLongIds { get; set; }
        }
        
    }
}
