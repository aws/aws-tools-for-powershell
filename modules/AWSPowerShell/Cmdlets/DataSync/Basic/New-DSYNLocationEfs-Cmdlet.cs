/*******************************************************************************
 *  Copyright 2012-2019 Amazon.com, Inc. or its affiliates. All Rights Reserved.
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
    [AWSCmdlet("Calls the AWS DataSync CreateLocationEfs API operation.", Operation = new[] {"CreateLocationEfs"}, SelectReturnType = typeof(Amazon.DataSync.Model.CreateLocationEfsResponse))]
    [AWSCmdletOutput("System.String or Amazon.DataSync.Model.CreateLocationEfsResponse",
        "This cmdlet returns a System.String object.",
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
        #if !MODULAR
        [System.Management.Automation.Parameter(ValueFromPipelineByPropertyName = true)]
        #else
        [System.Management.Automation.Parameter(ValueFromPipelineByPropertyName = true, Mandatory = true)]
        [System.Management.Automation.AllowEmptyString]
        [System.Management.Automation.AllowNull]
        #endif
        [Amazon.PowerShell.Common.AWSRequiredParameter]
        public System.String EfsFilesystemArn { get; set; }
        #endregion
        
        #region Parameter Ec2Config_SecurityGroupArn
        /// <summary>
        /// <para>
        /// <para>The Amazon Resource Names (ARNs) of the security groups that are configured for the
        /// Amazon EC2 resource.</para>
        /// </para>
        /// </summary>
        #if !MODULAR
        [System.Management.Automation.Parameter(ValueFromPipelineByPropertyName = true)]
        #else
        [System.Management.Automation.Parameter(ValueFromPipelineByPropertyName = true, Mandatory = true)]
        [System.Management.Automation.AllowEmptyCollection]
        [System.Management.Automation.AllowNull]
        #endif
        [Amazon.PowerShell.Common.AWSRequiredParameter]
        [Alias("Ec2Config_SecurityGroupArns")]
        public System.String[] Ec2Config_SecurityGroupArn { get; set; }
        #endregion
        
        #region Parameter Subdirectory
        /// <summary>
        /// <para>
        /// <para>A subdirectory in the location’s path. This subdirectory in the EFS file system is
        /// used to read data from the EFS source location or write data to the EFS destination.
        /// By default, AWS DataSync uses the root directory.</para><note><para><code>Subdirectory</code> must be specified with forward slashes. For example, <code>/path/to/folder</code>.</para></note>
        /// </para>
        /// </summary>
        [System.Management.Automation.Parameter(ValueFromPipelineByPropertyName = true)]
        public System.String Subdirectory { get; set; }
        #endregion
        
        #region Parameter Ec2Config_SubnetArn
        /// <summary>
        /// <para>
        /// <para>The ARN of the subnet and the security group that DataSync uses to access the target
        /// EFS file system.</para>
        /// </para>
        /// </summary>
        #if !MODULAR
        [System.Management.Automation.Parameter(ValueFromPipelineByPropertyName = true)]
        #else
        [System.Management.Automation.Parameter(ValueFromPipelineByPropertyName = true, Mandatory = true)]
        [System.Management.Automation.AllowEmptyString]
        [System.Management.Automation.AllowNull]
        #endif
        [Amazon.PowerShell.Common.AWSRequiredParameter]
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
        [System.Management.Automation.Parameter(ValueFromPipelineByPropertyName = true)]
        [Alias("Tags")]
        public Amazon.DataSync.Model.TagListEntry[] Tag { get; set; }
        #endregion
        
        #region Parameter Select
        /// <summary>
        /// Use the -Select parameter to control the cmdlet output. The default value is 'LocationArn'.
        /// Specifying -Select '*' will result in the cmdlet returning the whole service response (Amazon.DataSync.Model.CreateLocationEfsResponse).
        /// Specifying the name of a property of type Amazon.DataSync.Model.CreateLocationEfsResponse will result in that property being returned.
        /// Specifying -Select '^ParameterName' will result in the cmdlet returning the selected cmdlet parameter value.
        /// </summary>
        [System.Management.Automation.Parameter(ValueFromPipelineByPropertyName = true)]
        public string Select { get; set; } = "LocationArn";
        #endregion
        
        #region Parameter Force
        /// <summary>
        /// This parameter overrides confirmation prompts to force 
        /// the cmdlet to continue its operation. This parameter should always
        /// be used with caution.
        /// </summary>
        [System.Management.Automation.Parameter(ValueFromPipelineByPropertyName = true)]
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
            
            var context = new CmdletContext();
            
            // allow for manipulation of parameters prior to loading into context
            PreExecutionContextLoad(context);
            
            if (ParameterWasBound(nameof(this.Select)))
            {
                context.Select = CreateSelectDelegate<Amazon.DataSync.Model.CreateLocationEfsResponse, NewDSYNLocationEfsCmdlet>(Select) ??
                    throw new System.ArgumentException("Invalid value for -Select parameter.", nameof(this.Select));
            }
            if (this.Ec2Config_SecurityGroupArn != null)
            {
                context.Ec2Config_SecurityGroupArn = new List<System.String>(this.Ec2Config_SecurityGroupArn);
            }
            #if MODULAR
            if (this.Ec2Config_SecurityGroupArn == null && ParameterWasBound(nameof(this.Ec2Config_SecurityGroupArn)))
            {
                WriteWarning("You are passing $null as a value for parameter Ec2Config_SecurityGroupArn which is marked as required. In case you believe this parameter was incorrectly marked as required, report this by opening an issue at https://github.com/aws/aws-tools-for-powershell/issues.");
            }
            #endif
            context.Ec2Config_SubnetArn = this.Ec2Config_SubnetArn;
            #if MODULAR
            if (this.Ec2Config_SubnetArn == null && ParameterWasBound(nameof(this.Ec2Config_SubnetArn)))
            {
                WriteWarning("You are passing $null as a value for parameter Ec2Config_SubnetArn which is marked as required. In case you believe this parameter was incorrectly marked as required, report this by opening an issue at https://github.com/aws/aws-tools-for-powershell/issues.");
            }
            #endif
            context.EfsFilesystemArn = this.EfsFilesystemArn;
            #if MODULAR
            if (this.EfsFilesystemArn == null && ParameterWasBound(nameof(this.EfsFilesystemArn)))
            {
                WriteWarning("You are passing $null as a value for parameter EfsFilesystemArn which is marked as required. In case you believe this parameter was incorrectly marked as required, report this by opening an issue at https://github.com/aws/aws-tools-for-powershell/issues.");
            }
            #endif
            context.Subdirectory = this.Subdirectory;
            if (this.Tag != null)
            {
                context.Tag = new List<Amazon.DataSync.Model.TagListEntry>(this.Tag);
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
            var requestEc2ConfigIsNull = true;
            request.Ec2Config = new Amazon.DataSync.Model.Ec2Config();
            List<System.String> requestEc2Config_ec2Config_SecurityGroupArn = null;
            if (cmdletContext.Ec2Config_SecurityGroupArn != null)
            {
                requestEc2Config_ec2Config_SecurityGroupArn = cmdletContext.Ec2Config_SecurityGroupArn;
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
            if (cmdletContext.Tag != null)
            {
                request.Tags = cmdletContext.Tag;
            }
            
            CmdletOutput output;
            
            // issue call
            var client = Client ?? CreateClient(_CurrentCredentials, _RegionEndpoint);
            try
            {
                var response = CallAWSServiceOperation(client, request);
                object pipelineOutput = null;
                pipelineOutput = cmdletContext.Select(response, this);
                output = new CmdletOutput
                {
                    PipelineOutput = pipelineOutput,
                    ServiceResponse = response
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
                return client.CreateLocationEfsAsync(request).GetAwaiter().GetResult();
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
            public List<System.String> Ec2Config_SecurityGroupArn { get; set; }
            public System.String Ec2Config_SubnetArn { get; set; }
            public System.String EfsFilesystemArn { get; set; }
            public System.String Subdirectory { get; set; }
            public List<Amazon.DataSync.Model.TagListEntry> Tag { get; set; }
            public System.Func<Amazon.DataSync.Model.CreateLocationEfsResponse, NewDSYNLocationEfsCmdlet, object> Select { get; set; } =
                (response, cmdlet) => response.LocationArn;
        }
        
    }
}
