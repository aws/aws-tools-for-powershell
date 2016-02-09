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
using Amazon.GameLift;
using Amazon.GameLift.Model;

namespace Amazon.PowerShell.Cmdlets.GML
{
    /// <summary>
    /// Initializes a new build record and generates information required to upload a game
    /// build to Amazon GameLift. Once the build record has been created and is in an INITIALIZED
    /// state, you can upload your game build.
    /// 
    ///  <important><para>
    /// To create a build, use the CLI command <code>upload-build</code>, which creates a
    /// new build record and uploads the build files in one step. (See the <a href="http://docs.aws.amazon.com/gamelift/latest/developerguide/">Amazon
    /// GameLift Developer Guide</a> for more details on the CLI and the upload process.)
    /// Call the <code>CreateBuild</code> action only if you have your own Amazon Simple Storage
    /// Service (Amazon S3) client and need to manually upload your build files.
    /// </para></important><para>
    /// To create a new build, optionally specify a build name and version. This metadata
    /// is stored with other properties in the build record and is displayed in the GameLift
    /// console (but not visible to players). If successful, this action returns the newly
    /// created build record along with an Amazon S3 storage location and AWS account credentials.
    /// Use the location and credentials to upload your game build.
    /// </para>
    /// </summary>
    [Cmdlet("New", "GMLBuild", SupportsShouldProcess = true, ConfirmImpact = ConfirmImpact.Medium)]
    [OutputType("Amazon.GameLift.Model.CreateBuildResponse")]
    [AWSCmdlet("Invokes the CreateBuild operation against Amazon GameLift Service.", Operation = new[] {"CreateBuild"})]
    [AWSCmdletOutput("Amazon.GameLift.Model.CreateBuildResponse",
        "This cmdlet returns a Amazon.GameLift.Model.CreateBuildResponse object containing multiple properties. The object can also be referenced from properties attached to the cmdlet entry in the $AWSHistory stack."
    )]
    public class NewGMLBuildCmdlet : AmazonGameLiftClientCmdlet, IExecutor
    {
        
        #region Parameter Name
        /// <summary>
        /// <para>
        /// <para>Descriptive label associated with this build. Build names do not need to be unique.
        /// A build name can be changed later using <a>UpdateBuild</a>.</para>
        /// </para>
        /// </summary>
        [System.Management.Automation.Parameter]
        public System.String Name { get; set; }
        #endregion
        
        #region Parameter Version
        /// <summary>
        /// <para>
        /// <para>Version associated with this build. Version strings do not need to be unique to a
        /// build. A build version can be changed later using <a>UpdateBuild</a>.</para>
        /// </para>
        /// </summary>
        [System.Management.Automation.Parameter]
        public System.String Version { get; set; }
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
            if (!ConfirmShouldProceed(this.Force.IsPresent, resourceIdentifiersText, "New-GMLBuild (CreateBuild)"))
            {
                return;
            }
            
            var context = new CmdletContext
            {
                Region = this.Region,
                Credentials = this.CurrentCredentials
            };
            
            context.Name = this.Name;
            context.Version = this.Version;
            
            var output = Execute(context) as CmdletOutput;
            ProcessOutput(output);
        }
        
        #region IExecutor Members
        
        public object Execute(ExecutorContext context)
        {
            var cmdletContext = context as CmdletContext;
            // create request
            var request = new Amazon.GameLift.Model.CreateBuildRequest();
            
            if (cmdletContext.Name != null)
            {
                request.Name = cmdletContext.Name;
            }
            if (cmdletContext.Version != null)
            {
                request.Version = cmdletContext.Version;
            }
            
            CmdletOutput output;
            
            // issue call
            var client = Client ?? CreateClient(context.Credentials, context.Region);
            try
            {
                var response = client.CreateBuild(request);
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
        
        
        internal class CmdletContext : ExecutorContext
        {
            public System.String Name { get; set; }
            public System.String Version { get; set; }
        }
        
    }
}
