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
using Amazon.RAM;
using Amazon.RAM.Model;

namespace Amazon.PowerShell.Cmdlets.RAM
{
    /// <summary>
    /// Lists information about the managed permission and its associations to any resource
    /// shares that use this managed permission. This lets you see which resource shares use
    /// which versions of the specified managed permission.<br/><br/>This cmdlet automatically pages all available results to the pipeline - parameters related to iteration are only needed if you want to manually control the paginated output. To disable autopagination, use -NoAutoIteration.
    /// </summary>
    [Cmdlet("Get", "RAMPermissionAssociationList")]
    [OutputType("Amazon.RAM.Model.AssociatedPermission")]
    [AWSCmdlet("Calls the AWS Resource Access Manager (RAM) ListPermissionAssociations API operation.", Operation = new[] {"ListPermissionAssociations"}, SelectReturnType = typeof(Amazon.RAM.Model.ListPermissionAssociationsResponse))]
    [AWSCmdletOutput("Amazon.RAM.Model.AssociatedPermission or Amazon.RAM.Model.ListPermissionAssociationsResponse",
        "This cmdlet returns a collection of Amazon.RAM.Model.AssociatedPermission objects.",
        "The service call response (type Amazon.RAM.Model.ListPermissionAssociationsResponse) can be returned by specifying '-Select *'."
    )]
    public partial class GetRAMPermissionAssociationListCmdlet : AmazonRAMClientCmdlet, IExecutor
    {
        
        protected override bool IsGeneratedCmdlet { get; set; } = true;
        private readonly CancellationTokenSource _cancellationTokenSource = new CancellationTokenSource();
        
        #region Parameter AssociationStatus
        /// <summary>
        /// <para>
        /// <para>Specifies that you want to list only those associations with resource shares that
        /// match this status.</para>
        /// </para>
        /// </summary>
        [System.Management.Automation.Parameter(ValueFromPipelineByPropertyName = true)]
        [AWSConstantClassSource("Amazon.RAM.ResourceShareAssociationStatus")]
        public Amazon.RAM.ResourceShareAssociationStatus AssociationStatus { get; set; }
        #endregion
        
        #region Parameter DefaultVersion
        /// <summary>
        /// <para>
        /// <para>When <c>true</c>, specifies that you want to list only those associations with resource
        /// shares that use the default version of the specified managed permission.</para><para>When <c>false</c> (the default value), lists associations with resource shares that
        /// use any version of the specified managed permission.</para>
        /// </para>
        /// </summary>
        [System.Management.Automation.Parameter(ValueFromPipelineByPropertyName = true)]
        public System.Boolean? DefaultVersion { get; set; }
        #endregion
        
        #region Parameter FeatureSet
        /// <summary>
        /// <para>
        /// <para>Specifies that you want to list only those associations with resource shares that
        /// have a <c>featureSet</c> with this value.</para>
        /// </para>
        /// </summary>
        [System.Management.Automation.Parameter(ValueFromPipelineByPropertyName = true)]
        [AWSConstantClassSource("Amazon.RAM.PermissionFeatureSet")]
        public Amazon.RAM.PermissionFeatureSet FeatureSet { get; set; }
        #endregion
        
        #region Parameter PermissionArn
        /// <summary>
        /// <para>
        /// <para>Specifies the <a href="https://docs.aws.amazon.com/general/latest/gr/aws-arns-and-namespaces.html">Amazon
        /// Resource Name (ARN)</a> of the managed permission.</para>
        /// </para>
        /// </summary>
        [System.Management.Automation.Parameter(ValueFromPipelineByPropertyName = true)]
        public System.String PermissionArn { get; set; }
        #endregion
        
        #region Parameter PermissionVersion
        /// <summary>
        /// <para>
        /// <para>Specifies that you want to list only those associations with resource shares that
        /// use this version of the managed permission. If you don't provide a value for this
        /// parameter, then the operation returns information about associations with resource
        /// shares that use any version of the managed permission.</para>
        /// </para>
        /// </summary>
        [System.Management.Automation.Parameter(ValueFromPipelineByPropertyName = true)]
        public System.Int32? PermissionVersion { get; set; }
        #endregion
        
        #region Parameter ResourceType
        /// <summary>
        /// <para>
        /// <para>Specifies that you want to list only those associations with resource shares that
        /// include at least one resource of this resource type.</para>
        /// </para>
        /// </summary>
        [System.Management.Automation.Parameter(ValueFromPipelineByPropertyName = true)]
        public System.String ResourceType { get; set; }
        #endregion
        
        #region Parameter MaxResult
        /// <summary>
        /// <para>
        /// <para>Specifies the total number of results that you want included on each page of the response.
        /// If you do not include this parameter, it defaults to a value that is specific to the
        /// operation. If additional items exist beyond the number you specify, the <c>NextToken</c>
        /// response element is returned with a value (not null). Include the specified value
        /// as the <c>NextToken</c> request parameter in the next call to the operation to get
        /// the next part of the results. Note that the service might return fewer results than
        /// the maximum even when there are more results available. You should check <c>NextToken</c>
        /// after every operation to ensure that you receive all of the results.</para>
        /// </para>
        /// </summary>
        [System.Management.Automation.Parameter(ValueFromPipelineByPropertyName = true)]
        [Alias("MaxResults")]
        public System.Int32? MaxResult { get; set; }
        #endregion
        
        #region Parameter NextToken
        /// <summary>
        /// <para>
        /// <para>Specifies that you want to receive the next page of results. Valid only if you received
        /// a <c>NextToken</c> response in the previous request. If you did, it indicates that
        /// more output is available. Set this parameter to the value provided by the previous
        /// call's <c>NextToken</c> response to request the next page of results.</para>
        /// </para>
        /// <para>
        /// <br/><b>Note:</b> This parameter is only used if you are manually controlling output pagination of the service API call.
        /// <br/>'NextToken' is only returned by the cmdlet when '-Select *' is specified. In order to manually control output pagination, set '-NextToken' to null for the first call then set the 'NextToken' using the same property output from the previous call for subsequent calls.
        /// </para>
        /// </summary>
        [System.Management.Automation.Parameter(ValueFromPipelineByPropertyName = true)]
        public System.String NextToken { get; set; }
        #endregion
        
        #region Parameter Select
        /// <summary>
        /// Use the -Select parameter to control the cmdlet output. The default value is 'Permissions'.
        /// Specifying -Select '*' will result in the cmdlet returning the whole service response (Amazon.RAM.Model.ListPermissionAssociationsResponse).
        /// Specifying the name of a property of type Amazon.RAM.Model.ListPermissionAssociationsResponse will result in that property being returned.
        /// Specifying -Select '^ParameterName' will result in the cmdlet returning the selected cmdlet parameter value.
        /// </summary>
        [System.Management.Automation.Parameter(ValueFromPipelineByPropertyName = true)]
        public string Select { get; set; } = "Permissions";
        #endregion
        
        #region Parameter NoAutoIteration
        /// <summary>
        /// By default the cmdlet will auto-iterate and retrieve all results to the pipeline by performing multiple
        /// service calls. If set, the cmdlet will retrieve only the next 'page' of results using the value of NextToken
        /// as the start point.
        /// </summary>
        [System.Management.Automation.Parameter(ValueFromPipelineByPropertyName = true)]
        public SwitchParameter NoAutoIteration { get; set; }
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
                context.Select = CreateSelectDelegate<Amazon.RAM.Model.ListPermissionAssociationsResponse, GetRAMPermissionAssociationListCmdlet>(Select) ??
                    throw new System.ArgumentException("Invalid value for -Select parameter.", nameof(this.Select));
            }
            context.AssociationStatus = this.AssociationStatus;
            context.DefaultVersion = this.DefaultVersion;
            context.FeatureSet = this.FeatureSet;
            context.MaxResult = this.MaxResult;
            context.NextToken = this.NextToken;
            context.PermissionArn = this.PermissionArn;
            context.PermissionVersion = this.PermissionVersion;
            context.ResourceType = this.ResourceType;
            
            // allow further manipulation of loaded context prior to processing
            PostExecutionContextLoad(context);
            
            var output = Execute(context) as CmdletOutput;
            ProcessOutput(output);
        }
        
        #region IExecutor Members
        
        public object Execute(ExecutorContext context)
        {
            var cmdletContext = context as CmdletContext;
            var useParameterSelect = this.Select.StartsWith("^");
            
            // create request and set iteration invariants
            var request = new Amazon.RAM.Model.ListPermissionAssociationsRequest();
            
            if (cmdletContext.AssociationStatus != null)
            {
                request.AssociationStatus = cmdletContext.AssociationStatus;
            }
            if (cmdletContext.DefaultVersion != null)
            {
                request.DefaultVersion = cmdletContext.DefaultVersion.Value;
            }
            if (cmdletContext.FeatureSet != null)
            {
                request.FeatureSet = cmdletContext.FeatureSet;
            }
            if (cmdletContext.MaxResult != null)
            {
                request.MaxResults = cmdletContext.MaxResult.Value;
            }
            if (cmdletContext.PermissionArn != null)
            {
                request.PermissionArn = cmdletContext.PermissionArn;
            }
            if (cmdletContext.PermissionVersion != null)
            {
                request.PermissionVersion = cmdletContext.PermissionVersion.Value;
            }
            if (cmdletContext.ResourceType != null)
            {
                request.ResourceType = cmdletContext.ResourceType;
            }
            
            // Initialize loop variant and commence piping
            var _nextToken = cmdletContext.NextToken;
            var _userControllingPaging = this.NoAutoIteration.IsPresent || ParameterWasBound(nameof(this.NextToken));
            
            var client = Client ?? CreateClient(_CurrentCredentials, _RegionEndpoint);
            do
            {
                request.NextToken = _nextToken;
                
                CmdletOutput output;
                
                try
                {
                    
                    var response = CallAWSServiceOperation(client, request);
                    
                    object pipelineOutput = null;
                    if (!useParameterSelect)
                    {
                        pipelineOutput = cmdletContext.Select(response, this);
                    }
                    output = new CmdletOutput
                    {
                        PipelineOutput = pipelineOutput,
                        ServiceResponse = response
                    };
                    
                    _nextToken = response.NextToken;
                }
                catch (Exception e)
                {
                    output = new CmdletOutput { ErrorResponse = e };
                }
                
                ProcessOutput(output);
                
            } while (!_userControllingPaging && AutoIterationHelpers.HasValue(_nextToken));
            
            if (useParameterSelect)
            {
                WriteObject(cmdletContext.Select(null, this));
            }
            
            
            return null;
        }
        
        public ExecutorContext CreateContext()
        {
            return new CmdletContext();
        }
        
        #endregion
        
        #region AWS Service Operation Call
        
        private Amazon.RAM.Model.ListPermissionAssociationsResponse CallAWSServiceOperation(IAmazonRAM client, Amazon.RAM.Model.ListPermissionAssociationsRequest request)
        {
            Utils.Common.WriteVerboseEndpointMessage(this, client.Config, "AWS Resource Access Manager (RAM)", "ListPermissionAssociations");
            try
            {
                return client.ListPermissionAssociationsAsync(request, _cancellationTokenSource.Token).GetAwaiter().GetResult();
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
            public Amazon.RAM.ResourceShareAssociationStatus AssociationStatus { get; set; }
            public System.Boolean? DefaultVersion { get; set; }
            public Amazon.RAM.PermissionFeatureSet FeatureSet { get; set; }
            public System.Int32? MaxResult { get; set; }
            public System.String NextToken { get; set; }
            public System.String PermissionArn { get; set; }
            public System.Int32? PermissionVersion { get; set; }
            public System.String ResourceType { get; set; }
            public System.Func<Amazon.RAM.Model.ListPermissionAssociationsResponse, GetRAMPermissionAssociationListCmdlet, object> Select { get; set; } =
                (response, cmdlet) => response.Permissions;
        }
        
    }
}
