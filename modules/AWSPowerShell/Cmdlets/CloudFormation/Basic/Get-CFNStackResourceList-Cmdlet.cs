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
using System.Threading;
using Amazon.CloudFormation;
using Amazon.CloudFormation.Model;

namespace Amazon.PowerShell.Cmdlets.CFN
{
    /// <summary>
    /// Returns Amazon Web Services resource descriptions for running and deleted stacks.
    /// If <c>StackName</c> is specified, all the associated resources that are part of the
    /// stack are returned. If <c>PhysicalResourceId</c> is specified, the associated resources
    /// of the stack that the resource belongs to are returned.
    /// 
    ///  <note><para>
    /// Only the first 100 resources will be returned. If your stack has more resources than
    /// this, you should use <c>ListStackResources</c> instead.
    /// </para></note><para>
    /// For deleted stacks, <c>DescribeStackResources</c> returns resource information for
    /// up to 90 days after the stack has been deleted.
    /// </para><para>
    /// You must specify either <c>StackName</c> or <c>PhysicalResourceId</c>, but not both.
    /// In addition, you can specify <c>LogicalResourceId</c> to filter the returned result.
    /// For more information about resources, the <c>LogicalResourceId</c> and <c>PhysicalResourceId</c>,
    /// see the <a href="https://docs.aws.amazon.com/AWSCloudFormation/latest/UserGuide/">CloudFormation
    /// User Guide</a>.
    /// </para><note><para>
    /// A <c>ValidationError</c> is returned if you specify both <c>StackName</c> and <c>PhysicalResourceId</c>
    /// in the same request.
    /// </para></note>
    /// </summary>
    [Cmdlet("Get", "CFNStackResourceList")]
    [OutputType("Amazon.CloudFormation.Model.StackResource")]
    [AWSCmdlet("Calls the AWS CloudFormation DescribeStackResources API operation.", Operation = new[] {"DescribeStackResources"}, SelectReturnType = typeof(Amazon.CloudFormation.Model.DescribeStackResourcesResponse), LegacyAlias="Get-CFNStackResources")]
    [AWSCmdletOutput("Amazon.CloudFormation.Model.StackResource or Amazon.CloudFormation.Model.DescribeStackResourcesResponse",
        "This cmdlet returns a collection of Amazon.CloudFormation.Model.StackResource objects.",
        "The service call response (type Amazon.CloudFormation.Model.DescribeStackResourcesResponse) can be returned by specifying '-Select *'."
    )]
    public partial class GetCFNStackResourceListCmdlet : AmazonCloudFormationClientCmdlet, IExecutor
    {
        
        protected override bool IsGeneratedCmdlet { get; set; } = true;
        private readonly CancellationTokenSource _cancellationTokenSource = new CancellationTokenSource();
        
        #region Parameter LogicalResourceId
        /// <summary>
        /// <para>
        /// <para>The logical name of the resource as specified in the template.</para>
        /// </para>
        /// </summary>
        [System.Management.Automation.Parameter(ValueFromPipelineByPropertyName = true)]
        public System.String LogicalResourceId { get; set; }
        #endregion
        
        #region Parameter PhysicalResourceId
        /// <summary>
        /// <para>
        /// <para>The name or unique identifier that corresponds to a physical instance ID of a resource
        /// supported by CloudFormation.</para><para>For example, for an Amazon Elastic Compute Cloud (EC2) instance, <c>PhysicalResourceId</c>
        /// corresponds to the <c>InstanceId</c>. You can pass the EC2 <c>InstanceId</c> to <c>DescribeStackResources</c>
        /// to find which stack the instance belongs to and what other resources are part of the
        /// stack.</para><para>Required: Conditional. If you don't specify <c>PhysicalResourceId</c>, you must specify
        /// <c>StackName</c>.</para>
        /// </para>
        /// </summary>
        [System.Management.Automation.Parameter(ValueFromPipelineByPropertyName = true)]
        public System.String PhysicalResourceId { get; set; }
        #endregion
        
        #region Parameter StackName
        /// <summary>
        /// <para>
        /// <para>The name or the unique stack ID that is associated with the stack, which aren't always
        /// interchangeable:</para><ul><li><para>Running stacks: You can specify either the stack's name or its unique stack ID.</para></li><li><para>Deleted stacks: You must specify the unique stack ID.</para></li></ul><para>Required: Conditional. If you don't specify <c>StackName</c>, you must specify <c>PhysicalResourceId</c>.</para>
        /// </para>
        /// </summary>
        [System.Management.Automation.Parameter(Position = 0, ValueFromPipelineByPropertyName = true, ValueFromPipeline = true)]
        public System.String StackName { get; set; }
        #endregion
        
        #region Parameter Select
        /// <summary>
        /// Use the -Select parameter to control the cmdlet output. The default value is 'StackResources'.
        /// Specifying -Select '*' will result in the cmdlet returning the whole service response (Amazon.CloudFormation.Model.DescribeStackResourcesResponse).
        /// Specifying the name of a property of type Amazon.CloudFormation.Model.DescribeStackResourcesResponse will result in that property being returned.
        /// Specifying -Select '^ParameterName' will result in the cmdlet returning the selected cmdlet parameter value.
        /// </summary>
        [System.Management.Automation.Parameter(ValueFromPipelineByPropertyName = true)]
        public string Select { get; set; } = "StackResources";
        #endregion
        
        protected override void StopProcessing()
        {
            base.StopProcessing();
            _cancellationTokenSource.Cancel();
        }
        protected override void ProcessRecord()
        {
            this._AWSSignerType = "v4";
            base.ProcessRecord();
            
            var context = new CmdletContext();
            
            // allow for manipulation of parameters prior to loading into context
            PreExecutionContextLoad(context);
            
            if (ParameterWasBound(nameof(this.Select)))
            {
                context.Select = CreateSelectDelegate<Amazon.CloudFormation.Model.DescribeStackResourcesResponse, GetCFNStackResourceListCmdlet>(Select) ??
                    throw new System.ArgumentException("Invalid value for -Select parameter.", nameof(this.Select));
            }
            context.LogicalResourceId = this.LogicalResourceId;
            context.PhysicalResourceId = this.PhysicalResourceId;
            context.StackName = this.StackName;
            
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
            var request = new Amazon.CloudFormation.Model.DescribeStackResourcesRequest();
            
            if (cmdletContext.LogicalResourceId != null)
            {
                request.LogicalResourceId = cmdletContext.LogicalResourceId;
            }
            if (cmdletContext.PhysicalResourceId != null)
            {
                request.PhysicalResourceId = cmdletContext.PhysicalResourceId;
            }
            if (cmdletContext.StackName != null)
            {
                request.StackName = cmdletContext.StackName;
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
        
        private Amazon.CloudFormation.Model.DescribeStackResourcesResponse CallAWSServiceOperation(IAmazonCloudFormation client, Amazon.CloudFormation.Model.DescribeStackResourcesRequest request)
        {
            Utils.Common.WriteVerboseEndpointMessage(this, client.Config, "AWS CloudFormation", "DescribeStackResources");
            try
            {
                return client.DescribeStackResourcesAsync(request, _cancellationTokenSource.Token).GetAwaiter().GetResult();
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
            public System.String LogicalResourceId { get; set; }
            public System.String PhysicalResourceId { get; set; }
            public System.String StackName { get; set; }
            public System.Func<Amazon.CloudFormation.Model.DescribeStackResourcesResponse, GetCFNStackResourceListCmdlet, object> Select { get; set; } =
                (response, cmdlet) => response.StackResources;
        }
        
    }
}
