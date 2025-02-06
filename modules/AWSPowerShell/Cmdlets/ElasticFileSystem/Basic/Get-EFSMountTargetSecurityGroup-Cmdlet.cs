/*******************************************************************************
 *  Copyright Amazon.com, Inc. or its affiliates. All Rights Reserved.
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
using Amazon.ElasticFileSystem;
using Amazon.ElasticFileSystem.Model;

namespace Amazon.PowerShell.Cmdlets.EFS
{
    /// <summary>
    /// Returns the security groups currently in effect for a mount target. This operation
    /// requires that the network interface of the mount target has been created and the lifecycle
    /// state of the mount target is not <c>deleted</c>.
    /// 
    ///  
    /// <para>
    /// This operation requires permissions for the following actions:
    /// </para><ul><li><para><c>elasticfilesystem:DescribeMountTargetSecurityGroups</c> action on the mount target's
    /// file system. 
    /// </para></li><li><para><c>ec2:DescribeNetworkInterfaceAttribute</c> action on the mount target's network
    /// interface. 
    /// </para></li></ul>
    /// </summary>
    [Cmdlet("Get", "EFSMountTargetSecurityGroup")]
    [OutputType("System.String")]
    [AWSCmdlet("Calls the Amazon Elastic File System DescribeMountTargetSecurityGroups API operation.", Operation = new[] {"DescribeMountTargetSecurityGroups"}, SelectReturnType = typeof(Amazon.ElasticFileSystem.Model.DescribeMountTargetSecurityGroupsResponse))]
    [AWSCmdletOutput("System.String or Amazon.ElasticFileSystem.Model.DescribeMountTargetSecurityGroupsResponse",
        "This cmdlet returns a collection of System.String objects.",
        "The service call response (type Amazon.ElasticFileSystem.Model.DescribeMountTargetSecurityGroupsResponse) can be returned by specifying '-Select *'."
    )]
    public partial class GetEFSMountTargetSecurityGroupCmdlet : AmazonElasticFileSystemClientCmdlet, IExecutor
    {
        
        protected override bool IsGeneratedCmdlet { get; set; } = true;
        
        #region Parameter MountTargetId
        /// <summary>
        /// <para>
        /// <para>The ID of the mount target whose security groups you want to retrieve.</para>
        /// </para>
        /// </summary>
        #if !MODULAR
        [System.Management.Automation.Parameter(Position = 0, ValueFromPipelineByPropertyName = true, ValueFromPipeline = true)]
        #else
        [System.Management.Automation.Parameter(Position = 0, ValueFromPipelineByPropertyName = true, ValueFromPipeline = true, Mandatory = true)]
        [System.Management.Automation.AllowEmptyString]
        [System.Management.Automation.AllowNull]
        #endif
        [Amazon.PowerShell.Common.AWSRequiredParameter]
        public System.String MountTargetId { get; set; }
        #endregion
        
        #region Parameter Select
        /// <summary>
        /// Use the -Select parameter to control the cmdlet output. The default value is 'SecurityGroups'.
        /// Specifying -Select '*' will result in the cmdlet returning the whole service response (Amazon.ElasticFileSystem.Model.DescribeMountTargetSecurityGroupsResponse).
        /// Specifying the name of a property of type Amazon.ElasticFileSystem.Model.DescribeMountTargetSecurityGroupsResponse will result in that property being returned.
        /// Specifying -Select '^ParameterName' will result in the cmdlet returning the selected cmdlet parameter value.
        /// </summary>
        [System.Management.Automation.Parameter(ValueFromPipelineByPropertyName = true)]
        public string Select { get; set; } = "SecurityGroups";
        #endregion
        
        protected override void ProcessRecord()
        {
            this._AWSSignerType = "v4";
            base.ProcessRecord();
            
            var context = new CmdletContext();
            
            // allow for manipulation of parameters prior to loading into context
            PreExecutionContextLoad(context);
            
            if (ParameterWasBound(nameof(this.Select)))
            {
                context.Select = CreateSelectDelegate<Amazon.ElasticFileSystem.Model.DescribeMountTargetSecurityGroupsResponse, GetEFSMountTargetSecurityGroupCmdlet>(Select) ??
                    throw new System.ArgumentException("Invalid value for -Select parameter.", nameof(this.Select));
            }
            context.MountTargetId = this.MountTargetId;
            #if MODULAR
            if (this.MountTargetId == null && ParameterWasBound(nameof(this.MountTargetId)))
            {
                WriteWarning("You are passing $null as a value for parameter MountTargetId which is marked as required. In case you believe this parameter was incorrectly marked as required, report this by opening an issue at https://github.com/aws/aws-tools-for-powershell/issues.");
            }
            #endif
            
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
            var request = new Amazon.ElasticFileSystem.Model.DescribeMountTargetSecurityGroupsRequest();
            
            if (cmdletContext.MountTargetId != null)
            {
                request.MountTargetId = cmdletContext.MountTargetId;
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
        
        private Amazon.ElasticFileSystem.Model.DescribeMountTargetSecurityGroupsResponse CallAWSServiceOperation(IAmazonElasticFileSystem client, Amazon.ElasticFileSystem.Model.DescribeMountTargetSecurityGroupsRequest request)
        {
            Utils.Common.WriteVerboseEndpointMessage(this, client.Config, "Amazon Elastic File System", "DescribeMountTargetSecurityGroups");
            try
            {
                #if DESKTOP
                return client.DescribeMountTargetSecurityGroups(request);
                #elif CORECLR
                return client.DescribeMountTargetSecurityGroupsAsync(request).GetAwaiter().GetResult();
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
            public System.String MountTargetId { get; set; }
            public System.Func<Amazon.ElasticFileSystem.Model.DescribeMountTargetSecurityGroupsResponse, GetEFSMountTargetSecurityGroupCmdlet, object> Select { get; set; } =
                (response, cmdlet) => response.SecurityGroups;
        }
        
    }
}
