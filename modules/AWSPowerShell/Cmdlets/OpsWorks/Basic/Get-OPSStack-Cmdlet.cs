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
using Amazon.OpsWorks;
using Amazon.OpsWorks.Model;

namespace Amazon.PowerShell.Cmdlets.OPS
{
    /// <summary>
    /// Requests a description of one or more stacks.
    /// 
    ///  
    /// <para><b>Required Permissions</b>: To use this action, an IAM user must have a Show, Deploy,
    /// or Manage permissions level for the stack, or an attached policy that explicitly grants
    /// permissions. For more information about user permissions, see <a href="https://docs.aws.amazon.com/opsworks/latest/userguide/opsworks-security-users.html">Managing
    /// User Permissions</a>.
    /// </para>
    /// </summary>
    [Cmdlet("Get", "OPSStack")]
    [OutputType("Amazon.OpsWorks.Model.Stack")]
    [AWSCmdlet("Calls the AWS OpsWorks DescribeStacks API operation.", Operation = new[] {"DescribeStacks"}, SelectReturnType = typeof(Amazon.OpsWorks.Model.DescribeStacksResponse), LegacyAlias="Get-OPSStacks")]
    [AWSCmdletOutput("Amazon.OpsWorks.Model.Stack or Amazon.OpsWorks.Model.DescribeStacksResponse",
        "This cmdlet returns a collection of Amazon.OpsWorks.Model.Stack objects.",
        "The service call response (type Amazon.OpsWorks.Model.DescribeStacksResponse) can be returned by specifying '-Select *'."
    )]
    public partial class GetOPSStackCmdlet : AmazonOpsWorksClientCmdlet, IExecutor
    {
        
        protected override bool IsGeneratedCmdlet { get; set; } = true;
        
        #region Parameter StackId
        /// <summary>
        /// <para>
        /// <para>An array of stack IDs that specify the stacks to be described. If you omit this parameter,
        /// and have permissions to get information about all stacks, <c>DescribeStacks</c> returns
        /// a description of every stack. If the IAM policy that is attached to an IAM user limits
        /// the <c>DescribeStacks</c> action to specific stack ARNs, this parameter is required,
        /// and the user must specify a stack ARN that is allowed by the policy. Otherwise, <c>DescribeStacks</c>
        /// returns an <c>AccessDenied</c> error.</para>
        /// </para>
        /// </summary>
        [System.Management.Automation.Parameter(Position = 0, ValueFromPipelineByPropertyName = true, ValueFromPipeline = true)]
        [Alias("StackIds")]
        public System.String[] StackId { get; set; }
        #endregion
        
        #region Parameter Select
        /// <summary>
        /// Use the -Select parameter to control the cmdlet output. The default value is 'Stacks'.
        /// Specifying -Select '*' will result in the cmdlet returning the whole service response (Amazon.OpsWorks.Model.DescribeStacksResponse).
        /// Specifying the name of a property of type Amazon.OpsWorks.Model.DescribeStacksResponse will result in that property being returned.
        /// Specifying -Select '^ParameterName' will result in the cmdlet returning the selected cmdlet parameter value.
        /// </summary>
        [System.Management.Automation.Parameter(ValueFromPipelineByPropertyName = true)]
        public string Select { get; set; } = "Stacks";
        #endregion
        
        #region Parameter PassThru
        /// <summary>
        /// Changes the cmdlet behavior to return the value passed to the StackId parameter.
        /// The -PassThru parameter is deprecated, use -Select '^StackId' instead. This parameter will be removed in a future version.
        /// </summary>
        [System.Obsolete("The -PassThru parameter is deprecated, use -Select '^StackId' instead. This parameter will be removed in a future version.")]
        [System.Management.Automation.Parameter(ValueFromPipelineByPropertyName = true)]
        public SwitchParameter PassThru { get; set; }
        #endregion
        
        protected override void ProcessRecord()
        {
            this._AWSSignerType = "v4";
            base.ProcessRecord();
            
            var context = new CmdletContext();
            
            // allow for manipulation of parameters prior to loading into context
            PreExecutionContextLoad(context);
            
            #pragma warning disable CS0618, CS0612 //A class member was marked with the Obsolete attribute
            if (ParameterWasBound(nameof(this.Select)))
            {
                context.Select = CreateSelectDelegate<Amazon.OpsWorks.Model.DescribeStacksResponse, GetOPSStackCmdlet>(Select) ??
                    throw new System.ArgumentException("Invalid value for -Select parameter.", nameof(this.Select));
                if (this.PassThru.IsPresent)
                {
                    throw new System.ArgumentException("-PassThru cannot be used when -Select is specified.", nameof(this.Select));
                }
            }
            else if (this.PassThru.IsPresent)
            {
                context.Select = (response, cmdlet) => this.StackId;
            }
            #pragma warning restore CS0618, CS0612 //A class member was marked with the Obsolete attribute
            if (this.StackId != null)
            {
                context.StackId = new List<System.String>(this.StackId);
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
            var request = new Amazon.OpsWorks.Model.DescribeStacksRequest();
            
            if (cmdletContext.StackId != null)
            {
                request.StackIds = cmdletContext.StackId;
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
        
        private Amazon.OpsWorks.Model.DescribeStacksResponse CallAWSServiceOperation(IAmazonOpsWorks client, Amazon.OpsWorks.Model.DescribeStacksRequest request)
        {
            Utils.Common.WriteVerboseEndpointMessage(this, client.Config, "AWS OpsWorks", "DescribeStacks");
            try
            {
                #if DESKTOP
                return client.DescribeStacks(request);
                #elif CORECLR
                return client.DescribeStacksAsync(request).GetAwaiter().GetResult();
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
            public List<System.String> StackId { get; set; }
            public System.Func<Amazon.OpsWorks.Model.DescribeStacksResponse, GetOPSStackCmdlet, object> Select { get; set; } =
                (response, cmdlet) => response.Stacks;
        }
        
    }
}
