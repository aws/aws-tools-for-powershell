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
using Amazon.ElasticBeanstalk;
using Amazon.ElasticBeanstalk.Model;

namespace Amazon.PowerShell.Cmdlets.EB
{
    /// <summary>
    /// Creates an application version for the specified application.
    /// 
    ///  <note>Once you create an application version with a specified Amazon S3 bucket and
    /// key location, you cannot change that Amazon S3 location. If you change the Amazon
    /// S3 location, you receive an exception when you attempt to launch an environment from
    /// the application version. </note>
    /// </summary>
    [Cmdlet("New", "EBApplicationVersion", SupportsShouldProcess = true, ConfirmImpact = ConfirmImpact.Medium)]
    [OutputType("Amazon.ElasticBeanstalk.Model.ApplicationVersionDescription")]
    [AWSCmdlet("Invokes the CreateApplicationVersion operation against AWS Elastic Beanstalk.", Operation = new[] {"CreateApplicationVersion"})]
    [AWSCmdletOutput("Amazon.ElasticBeanstalk.Model.ApplicationVersionDescription",
        "This cmdlet returns a ApplicationVersionDescription object.",
        "The service call response (type Amazon.ElasticBeanstalk.Model.CreateApplicationVersionResponse) can also be referenced from properties attached to the cmdlet entry in the $AWSHistory stack."
    )]
    public class NewEBApplicationVersionCmdlet : AmazonElasticBeanstalkClientCmdlet, IExecutor
    {
        /// <summary>
        /// <para>
        /// <para> The name of the application. If no application is found with this name, and <code>AutoCreateApplication</code>
        /// is <code>false</code>, returns an <code>InvalidParameterValue</code> error. </para>
        /// </para>
        /// </summary>
        [System.Management.Automation.Parameter(Position = 0, ValueFromPipelineByPropertyName = true, ValueFromPipeline = true)]
        public System.String ApplicationName { get; set; }
        
        /// <summary>
        /// <para>
        /// <para> Determines how the system behaves if the specified application for this version does
        /// not already exist: </para><ul><li><code>true</code> : Automatically creates the specified application for
        /// this release if it does not already exist. </li><li><code>false</code> : Throws
        /// an <code>InvalidParameterValue</code> if the specified application for this release
        /// does not already exist. </li></ul><para> Default: <code>false</code></para><para> Valid Values: <code>true</code> | <code>false</code></para>
        /// </para>
        /// </summary>
        [System.Management.Automation.Parameter]
        public System.Boolean AutoCreateApplication { get; set; }
        
        /// <summary>
        /// <para>
        /// <para>Describes this version.</para>
        /// </para>
        /// </summary>
        [System.Management.Automation.Parameter(Position = 2)]
        public System.String Description { get; set; }
        
        /// <summary>
        /// <para>
        /// <para>Preprocesses and validates the environment manifest and configuration files in the
        /// source bundle. Validating configuration files can identify issues prior to deploying
        /// the application version to an environment.</para>
        /// </para>
        /// </summary>
        [System.Management.Automation.Parameter]
        public System.Boolean Process { get; set; }
        
        /// <summary>
        /// <para>
        /// <para>The Amazon S3 bucket where the data is located.</para>
        /// </para>
        /// </summary>
        [System.Management.Automation.Parameter]
        public System.String SourceBundle_S3Bucket { get; set; }
        
        /// <summary>
        /// <para>
        /// <para>The Amazon S3 key where the data is located.</para>
        /// </para>
        /// </summary>
        [System.Management.Automation.Parameter]
        public System.String SourceBundle_S3Key { get; set; }
        
        /// <summary>
        /// <para>
        /// <para>A label identifying this version.</para><para>Constraint: Must be unique per application. If an application version already exists
        /// with this label for the specified application, AWS Elastic Beanstalk returns an <code>InvalidParameterValue</code>
        /// error. </para>
        /// </para>
        /// </summary>
        [System.Management.Automation.Parameter(Position = 1, ValueFromPipelineByPropertyName = true)]
        public System.String VersionLabel { get; set; }
        
        /// <summary>
        /// This parameter overrides confirmation prompts to force 
        /// the cmdlet to continue its operation. This parameter should always
        /// be used with caution.
        /// </summary>
        [System.Management.Automation.Parameter]
        public SwitchParameter Force { get; set; }
        
        
        protected override void ProcessRecord()
        {
            base.ProcessRecord();
            
            var resourceIdentifiersText = FormatParameterValuesForConfirmationMsg("ApplicationName", MyInvocation.BoundParameters);
            if (!ConfirmShouldProceed(this.Force.IsPresent, resourceIdentifiersText, "New-EBApplicationVersion (CreateApplicationVersion)"))
            {
                return;
            }
            
            var context = new CmdletContext
            {
                Region = this.Region,
                Credentials = this.CurrentCredentials
            };
            
            context.ApplicationName = this.ApplicationName;
            if (ParameterWasBound("AutoCreateApplication"))
                context.AutoCreateApplication = this.AutoCreateApplication;
            context.Description = this.Description;
            if (ParameterWasBound("Process"))
                context.Process = this.Process;
            context.SourceBundle_S3Bucket = this.SourceBundle_S3Bucket;
            context.SourceBundle_S3Key = this.SourceBundle_S3Key;
            context.VersionLabel = this.VersionLabel;
            
            var output = Execute(context) as CmdletOutput;
            ProcessOutput(output);
        }
        
        #region IExecutor Members
        
        public object Execute(ExecutorContext context)
        {
            var cmdletContext = context as CmdletContext;
            // create request
            var request = new Amazon.ElasticBeanstalk.Model.CreateApplicationVersionRequest();
            
            if (cmdletContext.ApplicationName != null)
            {
                request.ApplicationName = cmdletContext.ApplicationName;
            }
            if (cmdletContext.AutoCreateApplication != null)
            {
                request.AutoCreateApplication = cmdletContext.AutoCreateApplication.Value;
            }
            if (cmdletContext.Description != null)
            {
                request.Description = cmdletContext.Description;
            }
            if (cmdletContext.Process != null)
            {
                request.Process = cmdletContext.Process.Value;
            }
            
             // populate SourceBundle
            bool requestSourceBundleIsNull = true;
            request.SourceBundle = new Amazon.ElasticBeanstalk.Model.S3Location();
            System.String requestSourceBundle_sourceBundle_S3Bucket = null;
            if (cmdletContext.SourceBundle_S3Bucket != null)
            {
                requestSourceBundle_sourceBundle_S3Bucket = cmdletContext.SourceBundle_S3Bucket;
            }
            if (requestSourceBundle_sourceBundle_S3Bucket != null)
            {
                request.SourceBundle.S3Bucket = requestSourceBundle_sourceBundle_S3Bucket;
                requestSourceBundleIsNull = false;
            }
            System.String requestSourceBundle_sourceBundle_S3Key = null;
            if (cmdletContext.SourceBundle_S3Key != null)
            {
                requestSourceBundle_sourceBundle_S3Key = cmdletContext.SourceBundle_S3Key;
            }
            if (requestSourceBundle_sourceBundle_S3Key != null)
            {
                request.SourceBundle.S3Key = requestSourceBundle_sourceBundle_S3Key;
                requestSourceBundleIsNull = false;
            }
             // determine if request.SourceBundle should be set to null
            if (requestSourceBundleIsNull)
            {
                request.SourceBundle = null;
            }
            if (cmdletContext.VersionLabel != null)
            {
                request.VersionLabel = cmdletContext.VersionLabel;
            }
            
            CmdletOutput output;
            
            // issue call
            var client = Client ?? CreateClient(context.Credentials, context.Region);
            try
            {
                var response = client.CreateApplicationVersion(request);
                Dictionary<string, object> notes = null;
                object pipelineOutput = response.ApplicationVersion;
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
            public System.String ApplicationName { get; set; }
            public System.Boolean? AutoCreateApplication { get; set; }
            public System.String Description { get; set; }
            public System.Boolean? Process { get; set; }
            public System.String SourceBundle_S3Bucket { get; set; }
            public System.String SourceBundle_S3Key { get; set; }
            public System.String VersionLabel { get; set; }
        }
        
    }
}
