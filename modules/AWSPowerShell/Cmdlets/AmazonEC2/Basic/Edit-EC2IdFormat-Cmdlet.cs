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
    /// Modifies the ID format for the specified resource on a per-region basis. You can specify
    /// that resources should receive longer IDs (17-character IDs) when they are created.
    /// The following resource types support longer IDs: <code>instance</code> | <code>reservation</code>.
    /// 
    ///  
    /// <para>
    /// This setting applies to the IAM user who makes the request; it does not apply to the
    /// entire AWS account. By default, an IAM user defaults to the same settings as the root
    /// user, unless they explicitly override the settings by running this request. Resources
    /// created with longer IDs are visible to all IAM users, regardless of these settings
    /// and provided that they have permission to use the relevant <code>Describe</code> command
    /// for the resource type.
    /// </para>
    /// </summary>
    [Cmdlet("Edit", "EC2IdFormat", SupportsShouldProcess = true, ConfirmImpact = ConfirmImpact.Medium)]
    [OutputType("None","System.String")]
    [AWSCmdlet("Invokes the ModifyIdFormat operation against Amazon Elastic Compute Cloud.", Operation = new[] {"ModifyIdFormat"})]
    [AWSCmdletOutput("None or System.String",
        "When you use the PassThru parameter, this cmdlet outputs the value supplied to the Resource parameter. Otherwise, this cmdlet does not return any output. " +
        "The service response (type Amazon.EC2.Model.ModifyIdFormatResponse) can be referenced from properties attached to the cmdlet entry in the $AWSHistory stack."
    )]
    public class EditEC2IdFormatCmdlet : AmazonEC2ClientCmdlet, IExecutor
    {
        
        #region Parameter Resource
        /// <summary>
        /// <para>
        /// <para>The type of resource.</para>
        /// </para>
        /// </summary>
        [System.Management.Automation.Parameter(Position = 0, ValueFromPipeline = true)]
        public System.String Resource { get; set; }
        #endregion
        
        #region Parameter UseLongId
        /// <summary>
        /// <para>
        /// <para>Indicate whether the resource should use longer IDs (17-character IDs).</para>
        /// </para>
        /// </summary>
        [System.Management.Automation.Parameter]
        [Alias("UseLongIds")]
        public System.Boolean UseLongId { get; set; }
        #endregion
        
        #region Parameter PassThru
        /// <summary>
        /// Returns the value passed to the Resource parameter.
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
            
            var resourceIdentifiersText = FormatParameterValuesForConfirmationMsg("UseLongId", MyInvocation.BoundParameters);
            if (!ConfirmShouldProceed(this.Force.IsPresent, resourceIdentifiersText, "Edit-EC2IdFormat (ModifyIdFormat)"))
            {
                return;
            }
            
            var context = new CmdletContext
            {
                Region = this.Region,
                Credentials = this.CurrentCredentials
            };
            
            context.Resource = this.Resource;
            if (ParameterWasBound("UseLongId"))
                context.UseLongIds = this.UseLongId;
            
            var output = Execute(context) as CmdletOutput;
            ProcessOutput(output);
        }
        
        #region IExecutor Members
        
        public object Execute(ExecutorContext context)
        {
            var cmdletContext = context as CmdletContext;
            // create request
            var request = new Amazon.EC2.Model.ModifyIdFormatRequest();
            
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
                var response = client.ModifyIdFormat(request);
                Dictionary<string, object> notes = null;
                object pipelineOutput = null;
                if (this.PassThru.IsPresent)
                    pipelineOutput = this.Resource;
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
            public System.String Resource { get; set; }
            public System.Boolean? UseLongIds { get; set; }
        }
        
    }
}
