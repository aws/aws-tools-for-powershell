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
using Amazon.EC2;
using Amazon.EC2.Model;

namespace Amazon.PowerShell.Cmdlets.EC2
{
    /// <summary>
    /// Describes the specified placement groups or all of your placement groups.
    /// 
    ///  <note><para>
    /// To describe a specific placement group that is <i>shared</i> with your account, you
    /// must specify the ID of the placement group using the <c>GroupId</c> parameter. Specifying
    /// the name of a <i>shared</i> placement group using the <c>GroupNames</c> parameter
    /// will result in an error.
    /// </para></note><para>
    /// For more information, see <a href="https://docs.aws.amazon.com/AWSEC2/latest/UserGuide/placement-groups.html">Placement
    /// groups</a> in the <i>Amazon EC2 User Guide</i>.
    /// </para>
    /// </summary>
    [Cmdlet("Get", "EC2PlacementGroup")]
    [OutputType("Amazon.EC2.Model.PlacementGroup")]
    [AWSCmdlet("Calls the Amazon Elastic Compute Cloud (EC2) DescribePlacementGroups API operation.", Operation = new[] {"DescribePlacementGroups"}, SelectReturnType = typeof(Amazon.EC2.Model.DescribePlacementGroupsResponse))]
    [AWSCmdletOutput("Amazon.EC2.Model.PlacementGroup or Amazon.EC2.Model.DescribePlacementGroupsResponse",
        "This cmdlet returns a collection of Amazon.EC2.Model.PlacementGroup objects.",
        "The service call response (type Amazon.EC2.Model.DescribePlacementGroupsResponse) can also be referenced from properties attached to the cmdlet entry in the $AWSHistory stack."
    )]
    public partial class GetEC2PlacementGroupCmdlet : AmazonEC2ClientCmdlet, IExecutor
    {
        
        protected override bool IsGeneratedCmdlet { get; set; } = true;
        
        #region Parameter Filter
        /// <summary>
        /// <para>
        /// <para>The filters.</para><ul><li><para><c>group-name</c> - The name of the placement group.</para></li><li><para><c>group-arn</c> - The Amazon Resource Name (ARN) of the placement group.</para></li><li><para><c>spread-level</c> - The spread level for the placement group (<c>host</c> | <c>rack</c>).
        /// </para></li><li><para><c>state</c> - The state of the placement group (<c>pending</c> | <c>available</c>
        /// | <c>deleting</c> | <c>deleted</c>).</para></li><li><para><c>strategy</c> - The strategy of the placement group (<c>cluster</c> | <c>spread</c>
        /// | <c>partition</c>).</para></li><li><para><c>tag:&lt;key&gt;</c> - The key/value combination of a tag assigned to the resource.
        /// Use the tag key in the filter name and the tag value as the filter value. For example,
        /// to find all resources that have a tag with the key <c>Owner</c> and the value <c>TeamA</c>,
        /// specify <c>tag:Owner</c> for the filter name and <c>TeamA</c> for the filter value.</para></li><li><para><c>tag-key</c> - The key of a tag assigned to the resource. Use this filter to find
        /// all resources that have a tag with a specific key, regardless of the tag value.</para></li></ul>
        /// </para>
        /// </summary>
        [System.Management.Automation.Parameter(Position = 1, ValueFromPipelineByPropertyName = true)]
        [Alias("Filters")]
        public Amazon.EC2.Model.Filter[] Filter { get; set; }
        #endregion
        
        #region Parameter GroupId
        /// <summary>
        /// <para>
        /// <para>The IDs of the placement groups.</para>
        /// </para>
        /// </summary>
        [System.Management.Automation.Parameter(ValueFromPipelineByPropertyName = true)]
        [Alias("GroupIds")]
        public System.String[] GroupId { get; set; }
        #endregion
        
        #region Parameter GroupName
        /// <summary>
        /// <para>
        /// <para>The names of the placement groups.</para><para>Constraints:</para><ul><li><para>You can specify a name only if the placement group is owned by your account.</para></li><li><para>If a placement group is <i>shared</i> with your account, specifying the name results
        /// in an error. You must use the <c>GroupId</c> parameter instead.</para></li></ul>
        /// </para>
        /// </summary>
        [System.Management.Automation.Parameter(Position = 0, ValueFromPipelineByPropertyName = true, ValueFromPipeline = true)]
        [Alias("GroupNames")]
        public System.String[] GroupName { get; set; }
        #endregion
        
        #region Parameter Select
        /// <summary>
        /// Use the -Select parameter to control the cmdlet output. The default value is 'PlacementGroups'.
        /// Specifying -Select '*' will result in the cmdlet returning the whole service response (Amazon.EC2.Model.DescribePlacementGroupsResponse).
        /// Specifying the name of a property of type Amazon.EC2.Model.DescribePlacementGroupsResponse will result in that property being returned.
        /// Specifying -Select '^ParameterName' will result in the cmdlet returning the selected cmdlet parameter value.
        /// </summary>
        [System.Management.Automation.Parameter(ValueFromPipelineByPropertyName = true)]
        public string Select { get; set; } = "PlacementGroups";
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
                context.Select = CreateSelectDelegate<Amazon.EC2.Model.DescribePlacementGroupsResponse, GetEC2PlacementGroupCmdlet>(Select) ??
                    throw new System.ArgumentException("Invalid value for -Select parameter.", nameof(this.Select));
            }
            if (this.Filter != null)
            {
                context.Filter = new List<Amazon.EC2.Model.Filter>(this.Filter);
            }
            if (this.GroupId != null)
            {
                context.GroupId = new List<System.String>(this.GroupId);
            }
            if (this.GroupName != null)
            {
                context.GroupName = new List<System.String>(this.GroupName);
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
            var request = new Amazon.EC2.Model.DescribePlacementGroupsRequest();
            
            if (cmdletContext.Filter != null)
            {
                request.Filters = cmdletContext.Filter;
            }
            if (cmdletContext.GroupId != null)
            {
                request.GroupIds = cmdletContext.GroupId;
            }
            if (cmdletContext.GroupName != null)
            {
                request.GroupNames = cmdletContext.GroupName;
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
        
        private Amazon.EC2.Model.DescribePlacementGroupsResponse CallAWSServiceOperation(IAmazonEC2 client, Amazon.EC2.Model.DescribePlacementGroupsRequest request)
        {
            Utils.Common.WriteVerboseEndpointMessage(this, client.Config, "Amazon Elastic Compute Cloud (EC2)", "DescribePlacementGroups");
            try
            {
                #if DESKTOP
                return client.DescribePlacementGroups(request);
                #elif CORECLR
                return client.DescribePlacementGroupsAsync(request).GetAwaiter().GetResult();
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
            public List<Amazon.EC2.Model.Filter> Filter { get; set; }
            public List<System.String> GroupId { get; set; }
            public List<System.String> GroupName { get; set; }
            public System.Func<Amazon.EC2.Model.DescribePlacementGroupsResponse, GetEC2PlacementGroupCmdlet, object> Select { get; set; } =
                (response, cmdlet) => response.PlacementGroups;
        }
        
    }
}
