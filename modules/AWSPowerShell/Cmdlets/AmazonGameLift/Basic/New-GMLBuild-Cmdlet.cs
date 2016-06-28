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
    /// build to Amazon GameLift. Once the build record has been created and is in an <code>INITIALIZED</code>
    /// state, you can upload your game build.
    /// 
    ///  <important><para>
    /// Do not use this API action unless you are using your own Amazon Simple Storage Service
    /// (Amazon S3) client and need to manually upload your build files. Instead, to create
    /// a build, use the CLI command <code>upload-build</code>, which creates a new build
    /// record and uploads the build files in one step. (See the <a href="http://docs.aws.amazon.com/gamelift/latest/developerguide/">Amazon
    /// GameLift Developer Guide</a> for more details on the CLI and the upload process.)
    /// 
    /// </para></important><para>
    /// To create a new build, optionally specify a build name and version. This metadata
    /// is stored with other properties in the build record and is displayed in the GameLift
    /// console (it is not visible to players). If successful, this action returns the newly
    /// created build record along with the Amazon S3 storage location and AWS account credentials.
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
        
        #region Parameter StorageLocation_Bucket
        /// <summary>
        /// <para>
        /// <para>Amazon S3 bucket identifier.</para>
        /// </para>
        /// </summary>
        [System.Management.Automation.Parameter]
        public System.String StorageLocation_Bucket { get; set; }
        #endregion
        
        #region Parameter StorageLocation_Key
        /// <summary>
        /// <para>
        /// <para>Amazon S3 bucket key.</para>
        /// </para>
        /// </summary>
        [System.Management.Automation.Parameter]
        public System.String StorageLocation_Key { get; set; }
        #endregion
        
        #region Parameter Name
        /// <summary>
        /// <para>
        /// <para>Descriptive label associated with a build. Build names do not need to be unique. A
        /// build name can be changed later using <code><a>UpdateBuild</a></code>.</para>
        /// </para>
        /// </summary>
        [System.Management.Automation.Parameter]
        public System.String Name { get; set; }
        #endregion
        
        #region Parameter StorageLocation_RoleArn
        /// <summary>
        /// <para>
        /// <para>Amazon resource number for the cross-account access role that allows GameLift access
        /// to the S3 bucket.</para>
        /// </para>
        /// </summary>
        [System.Management.Automation.Parameter]
        public System.String StorageLocation_RoleArn { get; set; }
        #endregion
        
        #region Parameter Version
        /// <summary>
        /// <para>
        /// <para>Version associated with this build. Version strings do not need to be unique to a
        /// build. A build version can be changed later using <code><a>UpdateBuild</a></code>.</para>
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
            context.StorageLocation_Bucket = this.StorageLocation_Bucket;
            context.StorageLocation_Key = this.StorageLocation_Key;
            context.StorageLocation_RoleArn = this.StorageLocation_RoleArn;
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
            
             // populate StorageLocation
            bool requestStorageLocationIsNull = true;
            request.StorageLocation = new Amazon.GameLift.Model.S3Location();
            System.String requestStorageLocation_storageLocation_Bucket = null;
            if (cmdletContext.StorageLocation_Bucket != null)
            {
                requestStorageLocation_storageLocation_Bucket = cmdletContext.StorageLocation_Bucket;
            }
            if (requestStorageLocation_storageLocation_Bucket != null)
            {
                request.StorageLocation.Bucket = requestStorageLocation_storageLocation_Bucket;
                requestStorageLocationIsNull = false;
            }
            System.String requestStorageLocation_storageLocation_Key = null;
            if (cmdletContext.StorageLocation_Key != null)
            {
                requestStorageLocation_storageLocation_Key = cmdletContext.StorageLocation_Key;
            }
            if (requestStorageLocation_storageLocation_Key != null)
            {
                request.StorageLocation.Key = requestStorageLocation_storageLocation_Key;
                requestStorageLocationIsNull = false;
            }
            System.String requestStorageLocation_storageLocation_RoleArn = null;
            if (cmdletContext.StorageLocation_RoleArn != null)
            {
                requestStorageLocation_storageLocation_RoleArn = cmdletContext.StorageLocation_RoleArn;
            }
            if (requestStorageLocation_storageLocation_RoleArn != null)
            {
                request.StorageLocation.RoleArn = requestStorageLocation_storageLocation_RoleArn;
                requestStorageLocationIsNull = false;
            }
             // determine if request.StorageLocation should be set to null
            if (requestStorageLocationIsNull)
            {
                request.StorageLocation = null;
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
        
        private static Amazon.GameLift.Model.CreateBuildResponse CallAWSServiceOperation(IAmazonGameLift client, Amazon.GameLift.Model.CreateBuildRequest request)
        {
            return client.CreateBuild(request);
        }
        
        #endregion
        
        internal class CmdletContext : ExecutorContext
        {
            public System.String Name { get; set; }
            public System.String StorageLocation_Bucket { get; set; }
            public System.String StorageLocation_Key { get; set; }
            public System.String StorageLocation_RoleArn { get; set; }
            public System.String Version { get; set; }
        }
        
    }
}
