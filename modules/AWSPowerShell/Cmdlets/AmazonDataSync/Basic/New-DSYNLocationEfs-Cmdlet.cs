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
using Amazon.DataSync;
using Amazon.DataSync.Model;

namespace Amazon.PowerShell.Cmdlets.DSYN
{
    /// <summary>
    /// Creates an endpoint for an Amazon EFS file system.
    /// </summary>
    [Cmdlet("New", "DSYNLocationEfs", SupportsShouldProcess = true, ConfirmImpact = ConfirmImpact.Medium)]
    [OutputType("System.String")]
    [AWSCmdlet("Calls the AWS DataSync CreateLocationEfs API operation.", Operation = new[] {"CreateLocationEfs"})]
    [AWSCmdletOutput("System.String",
        "This cmdlet returns a String object.",
        "The service call response (type Amazon.DataSync.Model.CreateLocationEfsResponse) can also be referenced from properties attached to the cmdlet entry in the $AWSHistory stack."
    )]
    public partial class NewDSYNLocationEfsCmdlet : AmazonDataSyncClientCmdlet, IExecutor
    {
        
        #region Parameter EfsFilesystemArn
        /// <summary>
        /// <para>
        /// <para>The Amazon Resource Name (ARN) for the Amazon EFS file system.</para>
        /// </para>
        /// </summary>
        [System.Management.Automation.Parameter]
        public System.String EfsFilesystemArn { get; set; }
        #endregion
        
        #region Parameter Ec2Config_SecurityGroupArn
        /// <summary>
        /// <para>
        /// <para>The Amazon Resource Names (ARNs) of the security groups that are configured for the
        /// Amazon EC2 resource.</para>
        /// </para>
        /// </summary>
        [System.Management.Automation.Parameter]
        [Alias("Ec2Config_SecurityGroupArns")]
        public System.String[] Ec2Config_SecurityGroupArn { get; set; }
        #endregion
        
        #region Parameter Subdirectory
        /// <summary>
        /// <para>
        /// <para>A subdirectory in the location’s path. This subdirectory in the EFS file system is
        /// used to read data from the EFS source location or write data to the EFS destination.
        /// By default, AWS DataSync uses the root directory.</para>
        /// </para>
        /// </summary>
        [System.Management.Automation.Parameter]
        public System.String Subdirectory { get; set; }
        #endregion
        
        #region Parameter Ec2Config_SubnetArn
        /// <summary>
        /// <para>
        /// <para>The ARN of the subnet that the Amazon EC2 resource belongs in. </para>
        /// </para>
        /// </summary>
        [System.Management.Automation.Parameter]
        public System.String Ec2Config_SubnetArn { get; set; }
        #endregion
        
        #region Parameter Tag
        /// <summary>
        /// <para>
        /// <para>The key-value pair that represents a tag that you want to add to the resource. The
        /// value can be an empty string. This value helps you manage, filter, and search for
        /// your resources. We recommend that you create a name tag for your location.</para>
        /// </para>
        /// </summary>
        [System.Management.Automation.Parameter]
        [Alias("Tags")]
        public Amazon.DataSync.Model.TagListEntry[] Tag { get; set; }
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
            
            var resourceIdentifiersText = string.Empty;
            if (!ConfirmShouldProceed(this.Force.IsPresent, resourceIdentifiersText, "New-DSYNLocationEfs (CreateLocationEfs)"))
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
            
            if (this.Ec2Config_SecurityGroupArn != null)
            {
                context.Ec2Config_SecurityGroupArns = new List<System.String>(this.Ec2Config_SecurityGroupArn);
            }
            context.Ec2Config_SubnetArn = this.Ec2Config_SubnetArn;
            context.EfsFilesystemArn = this.EfsFilesystemArn;
            context.Subdirectory = this.Subdirectory;
            if (this.Tag != null)
            {
                context.Tags = new List<Amazon.DataSync.Model.TagListEntry>(this.Tag);
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
            var request = new Amazon.DataSync.Model.CreateLocationEfsRequest();
            
            
             // populate Ec2Config
            bool requestEc2ConfigIsNull = true;
            request.Ec2Config = new Amazon.DataSync.Model.Ec2Config();
            List<System.String> requestEc2Config_ec2Config_SecurityGroupArn = null;
            if (cmdletContext.Ec2Config_SecurityGroupArns != null)
            {
                requestEc2Config_ec2Config_SecurityGroupArn = cmdletContext.Ec2Config_SecurityGroupArns;
            }
            if (requestEc2Config_ec2Config_SecurityGroupArn != null)
            {
                request.Ec2Config.SecurityGroupArns = requestEc2Config_ec2Config_SecurityGroupArn;
                requestEc2ConfigIsNull = false;
            }
            System.String requestEc2Config_ec2Config_SubnetArn = null;
            if (cmdletContext.Ec2Config_SubnetArn != null)
            {
                requestEc2Config_ec2Config_SubnetArn = cmdletContext.Ec2Config_SubnetArn;
            }
            if (requestEc2Config_ec2Config_SubnetArn != null)
            {
                request.Ec2Config.SubnetArn = requestEc2Config_ec2Config_SubnetArn;
                requestEc2ConfigIsNull = false;
            }
             // determine if request.Ec2Config should be set to null
            if (requestEc2ConfigIsNull)
            {
                request.Ec2Config = null;
            }
            if (cmdletContext.EfsFilesystemArn != null)
            {
                request.EfsFilesystemArn = cmdletContext.EfsFilesystemArn;
            }
            if (cmdletContext.Subdirectory != null)
            {
                request.Subdirectory = cmdletContext.Subdirectory;
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
                object pipelineOutput = response.LocationArn;
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
        
        private Amazon.DataSync.Model.CreateLocationEfsResponse CallAWSServiceOperation(IAmazonDataSync client, Amazon.DataSync.Model.CreateLocationEfsRequest request)
        {
            Utils.Common.WriteVerboseEndpointMessage(this, client.Config, "AWS DataSync", "CreateLocationEfs");
            try
            {
                #if DESKTOP
                return client.CreateLocationEfs(request);
                #elif CORECLR
                // todo: handle AggregateException and extract true service exception for rethrow
                var task = client.CreateLocationEfsAsync(request);
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
            public List<System.String> Ec2Config_SecurityGroupArns { get; set; }
            public System.String Ec2Config_SubnetArn { get; set; }
            public System.String EfsFilesystemArn { get; set; }
            public System.String Subdirectory { get; set; }
            public List<Amazon.DataSync.Model.TagListEntry> Tags { get; set; }
        }
        
    }
}
