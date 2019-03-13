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
using Amazon.Neptune;
using Amazon.Neptune.Model;

namespace Amazon.PowerShell.Cmdlets.NPT
{
    /// <summary>
    /// Copies the specified DB parameter group.
    /// </summary>
    [Cmdlet("Copy", "NPTDBParameterGroup", SupportsShouldProcess = true, ConfirmImpact = ConfirmImpact.Medium)]
    [OutputType("Amazon.Neptune.Model.DBParameterGroup")]
    [AWSCmdlet("Calls the Amazon Neptune CopyDBParameterGroup API operation.", Operation = new[] {"CopyDBParameterGroup"})]
    [AWSCmdletOutput("Amazon.Neptune.Model.DBParameterGroup",
        "This cmdlet returns a DBParameterGroup object.",
        "The service call response (type Amazon.Neptune.Model.CopyDBParameterGroupResponse) can also be referenced from properties attached to the cmdlet entry in the $AWSHistory stack."
    )]
    public partial class CopyNPTDBParameterGroupCmdlet : AmazonNeptuneClientCmdlet, IExecutor
    {
        
        #region Parameter SourceDBParameterGroupIdentifier
        /// <summary>
        /// <para>
        /// <para> The identifier or ARN for the source DB parameter group. For information about creating
        /// an ARN, see <a href="http://docs.aws.amazon.com/neptune/latest/UserGuide/tagging.ARN.html#tagging.ARN.Constructing">
        /// Constructing an Amazon Resource Name (ARN)</a>. </para><para>Constraints:</para><ul><li><para>Must specify a valid DB parameter group.</para></li><li><para>Must specify a valid DB parameter group identifier, for example <code>my-db-param-group</code>,
        /// or a valid ARN.</para></li></ul>
        /// </para>
        /// </summary>
        [System.Management.Automation.Parameter(Position = 0, ValueFromPipeline = true)]
        public System.String SourceDBParameterGroupIdentifier { get; set; }
        #endregion
        
        #region Parameter Tag
        /// <summary>
        /// <para>
        /// The service has not provided documentation for this parameter; please refer to the service's API reference documentation for the latest available information.
        /// </para>
        /// </summary>
        [System.Management.Automation.Parameter]
        [Alias("Tags")]
        public Amazon.Neptune.Model.Tag[] Tag { get; set; }
        #endregion
        
        #region Parameter TargetDBParameterGroupDescription
        /// <summary>
        /// <para>
        /// <para>A description for the copied DB parameter group.</para>
        /// </para>
        /// </summary>
        [System.Management.Automation.Parameter]
        public System.String TargetDBParameterGroupDescription { get; set; }
        #endregion
        
        #region Parameter TargetDBParameterGroupIdentifier
        /// <summary>
        /// <para>
        /// <para>The identifier for the copied DB parameter group.</para><para>Constraints:</para><ul><li><para>Cannot be null, empty, or blank</para></li><li><para>Must contain from 1 to 255 letters, numbers, or hyphens</para></li><li><para>First character must be a letter</para></li><li><para>Cannot end with a hyphen or contain two consecutive hyphens</para></li></ul><para>Example: <code>my-db-parameter-group</code></para>
        /// </para>
        /// </summary>
        [System.Management.Automation.Parameter]
        public System.String TargetDBParameterGroupIdentifier { get; set; }
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
            
            var resourceIdentifiersText = FormatParameterValuesForConfirmationMsg("SourceDBParameterGroupIdentifier", MyInvocation.BoundParameters);
            if (!ConfirmShouldProceed(this.Force.IsPresent, resourceIdentifiersText, "Copy-NPTDBParameterGroup (CopyDBParameterGroup)"))
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
            
            context.SourceDBParameterGroupIdentifier = this.SourceDBParameterGroupIdentifier;
            if (this.Tag != null)
            {
                context.Tags = new List<Amazon.Neptune.Model.Tag>(this.Tag);
            }
            context.TargetDBParameterGroupDescription = this.TargetDBParameterGroupDescription;
            context.TargetDBParameterGroupIdentifier = this.TargetDBParameterGroupIdentifier;
            
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
            var request = new Amazon.Neptune.Model.CopyDBParameterGroupRequest();
            
            if (cmdletContext.SourceDBParameterGroupIdentifier != null)
            {
                request.SourceDBParameterGroupIdentifier = cmdletContext.SourceDBParameterGroupIdentifier;
            }
            if (cmdletContext.Tags != null)
            {
                request.Tags = cmdletContext.Tags;
            }
            if (cmdletContext.TargetDBParameterGroupDescription != null)
            {
                request.TargetDBParameterGroupDescription = cmdletContext.TargetDBParameterGroupDescription;
            }
            if (cmdletContext.TargetDBParameterGroupIdentifier != null)
            {
                request.TargetDBParameterGroupIdentifier = cmdletContext.TargetDBParameterGroupIdentifier;
            }
            
            CmdletOutput output;
            
            // issue call
            var client = Client ?? CreateClient(context.Credentials, context.Region);
            try
            {
                var response = CallAWSServiceOperation(client, request);
                Dictionary<string, object> notes = null;
                object pipelineOutput = response.DBParameterGroup;
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
        
        private Amazon.Neptune.Model.CopyDBParameterGroupResponse CallAWSServiceOperation(IAmazonNeptune client, Amazon.Neptune.Model.CopyDBParameterGroupRequest request)
        {
            Utils.Common.WriteVerboseEndpointMessage(this, client.Config, "Amazon Neptune", "CopyDBParameterGroup");
            try
            {
                #if DESKTOP
                return client.CopyDBParameterGroup(request);
                #elif CORECLR
                return client.CopyDBParameterGroupAsync(request).GetAwaiter().GetResult();
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
            public System.String SourceDBParameterGroupIdentifier { get; set; }
            public List<Amazon.Neptune.Model.Tag> Tags { get; set; }
            public System.String TargetDBParameterGroupDescription { get; set; }
            public System.String TargetDBParameterGroupIdentifier { get; set; }
        }
        
    }
}
