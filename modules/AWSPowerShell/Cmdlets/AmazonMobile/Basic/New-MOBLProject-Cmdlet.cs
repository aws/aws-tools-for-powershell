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
using Amazon.Mobile;
using Amazon.Mobile.Model;

namespace Amazon.PowerShell.Cmdlets.MOBL
{
    /// <summary>
    /// Creates an AWS Mobile Hub project.
    /// </summary>
    [Cmdlet("New", "MOBLProject", SupportsShouldProcess = true, ConfirmImpact = ConfirmImpact.Medium)]
    [OutputType("Amazon.Mobile.Model.ProjectDetails")]
    [AWSCmdlet("Calls the AWS Mobile CreateProject API operation.", Operation = new[] {"CreateProject"})]
    [AWSCmdletOutput("Amazon.Mobile.Model.ProjectDetails",
        "This cmdlet returns a ProjectDetails object.",
        "The service call response (type Amazon.Mobile.Model.CreateProjectResponse) can also be referenced from properties attached to the cmdlet entry in the $AWSHistory stack."
    )]
    public partial class NewMOBLProjectCmdlet : AmazonMobileClientCmdlet, IExecutor
    {
        
        #region Parameter Content
        /// <summary>
        /// <para>
        /// <para> ZIP or YAML file which contains configuration settings to be used when creating the
        /// project. This may be the contents of the file downloaded from the URL provided in
        /// an export project operation. </para>
        /// </para>
        /// </summary>
        [System.Management.Automation.Parameter]
        [Alias("Contents")]
        public byte[] Content { get; set; }
        #endregion
        
        #region Parameter Name
        /// <summary>
        /// <para>
        /// <para> Name of the project. </para>
        /// </para>
        /// </summary>
        [System.Management.Automation.Parameter(Position = 0, ValueFromPipeline = true)]
        public System.String Name { get; set; }
        #endregion
        
        #region Parameter Region
        /// <summary>
        /// <para>
        /// <para> Default region where project resources should be created. </para>
        /// </para>
        /// </summary>
        [System.Management.Automation.Parameter]
        public System.String Region { get; set; }
        #endregion
        
        #region Parameter SnapshotId
        /// <summary>
        /// <para>
        /// <para> Unique identifier for an exported snapshot of project configuration. This snapshot
        /// identifier is included in the share URL when a project is exported. </para>
        /// </para>
        /// </summary>
        [System.Management.Automation.Parameter]
        public System.String SnapshotId { get; set; }
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
            
            var resourceIdentifiersText = FormatParameterValuesForConfirmationMsg("Name", MyInvocation.BoundParameters);
            if (!ConfirmShouldProceed(this.Force.IsPresent, resourceIdentifiersText, "New-MOBLProject (CreateProject)"))
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
            
            context.Contents = this.Content;
            context.Name = this.Name;
            context.Region = this.Region;
            context.SnapshotId = this.SnapshotId;
            
            // allow further manipulation of loaded context prior to processing
            PostExecutionContextLoad(context);
            
            var output = Execute(context) as CmdletOutput;
            ProcessOutput(output);
        }
        
        #region IExecutor Members
        
        public object Execute(ExecutorContext context)
        {
            System.IO.MemoryStream _ContentsStream = null;
            
            try
            {
                var cmdletContext = context as CmdletContext;
                // create request
                var request = new Amazon.Mobile.Model.CreateProjectRequest();
                
                if (cmdletContext.Contents != null)
                {
                    _ContentsStream = new System.IO.MemoryStream(cmdletContext.Contents);
                    request.Contents = _ContentsStream;
                }
                if (cmdletContext.Name != null)
                {
                    request.Name = cmdletContext.Name;
                }
                if (cmdletContext.Region != null)
                {
                    request.Region = cmdletContext.Region;
                }
                if (cmdletContext.SnapshotId != null)
                {
                    request.SnapshotId = cmdletContext.SnapshotId;
                }
                
                CmdletOutput output;
                
                // issue call
                var client = Client ?? CreateClient(context.Credentials, context.Region);
                try
                {
                    var response = CallAWSServiceOperation(client, request);
                    Dictionary<string, object> notes = null;
                    object pipelineOutput = response.Details;
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
            finally
            {
                if( _ContentsStream != null)
                {
                    _ContentsStream.Dispose();
                }
            }
        }
        
        public ExecutorContext CreateContext()
        {
            return new CmdletContext();
        }
        
        #endregion
        
        #region AWS Service Operation Call
        
        private Amazon.Mobile.Model.CreateProjectResponse CallAWSServiceOperation(IAmazonMobile client, Amazon.Mobile.Model.CreateProjectRequest request)
        {
            Utils.Common.WriteVerboseEndpointMessage(this, client.Config, "AWS Mobile", "CreateProject");
            try
            {
                #if DESKTOP
                return client.CreateProject(request);
                #elif CORECLR
                // todo: handle AggregateException and extract true service exception for rethrow
                var task = client.CreateProjectAsync(request);
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
            public byte[] Contents { get; set; }
            public System.String Name { get; set; }
            public System.String Region { get; set; }
            public System.String SnapshotId { get; set; }
        }
        
    }
}
