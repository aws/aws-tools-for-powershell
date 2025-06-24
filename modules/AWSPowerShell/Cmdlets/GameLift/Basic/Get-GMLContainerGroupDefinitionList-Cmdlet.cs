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
using Amazon.GameLift;
using Amazon.GameLift.Model;

namespace Amazon.PowerShell.Cmdlets.GML
{
    /// <summary>
    /// Retrieves container group definitions for the Amazon Web Services account and Amazon
    /// Web Services Region. Use the pagination parameters to retrieve results in a set of
    /// sequential pages.
    /// 
    ///  
    /// <para>
    /// This operation returns only the latest version of each definition. To retrieve all
    /// versions of a container group definition, use <a href="https://docs.aws.amazon.com/gamelift/latest/apireference/API_ListContainerGroupDefinitionVersions.html">ListContainerGroupDefinitionVersions</a>.
    /// </para><para><b>Request options:</b></para><ul><li><para>
    /// Retrieve the most recent versions of all container group definitions. 
    /// </para></li><li><para>
    /// Retrieve the most recent versions of all container group definitions, filtered by
    /// type. Specify the container group type to filter on. 
    /// </para></li></ul><para><b>Results:</b></para><para>
    /// If successful, this operation returns the complete properties of a set of container
    /// group definition versions that match the request.
    /// </para><note><para>
    /// This operation returns the list of container group definitions in no particular order.
    /// 
    /// </para></note><br/><br/>This cmdlet automatically pages all available results to the pipeline - parameters related to iteration are only needed if you want to manually control the paginated output. To disable autopagination, use -NoAutoIteration.
    /// </summary>
    [Cmdlet("Get", "GMLContainerGroupDefinitionList")]
    [OutputType("Amazon.GameLift.Model.ContainerGroupDefinition")]
    [AWSCmdlet("Calls the Amazon GameLift Service ListContainerGroupDefinitions API operation.", Operation = new[] {"ListContainerGroupDefinitions"}, SelectReturnType = typeof(Amazon.GameLift.Model.ListContainerGroupDefinitionsResponse))]
    [AWSCmdletOutput("Amazon.GameLift.Model.ContainerGroupDefinition or Amazon.GameLift.Model.ListContainerGroupDefinitionsResponse",
        "This cmdlet returns a collection of Amazon.GameLift.Model.ContainerGroupDefinition objects.",
        "The service call response (type Amazon.GameLift.Model.ListContainerGroupDefinitionsResponse) can be returned by specifying '-Select *'."
    )]
    public partial class GetGMLContainerGroupDefinitionListCmdlet : AmazonGameLiftClientCmdlet, IExecutor
    {
        
        protected override bool IsSensitiveResponse { get; set; } = true;
        
        protected override bool IsGeneratedCmdlet { get; set; } = true;
        
        #region Parameter ContainerGroupType
        /// <summary>
        /// <para>
        /// <para>The type of container group to retrieve. Container group type determines how Amazon
        /// GameLift Servers deploys the container group on each fleet instance.</para>
        /// </para>
        /// </summary>
        [System.Management.Automation.Parameter(Position = 0, ValueFromPipelineByPropertyName = true, ValueFromPipeline = true)]
        [AWSConstantClassSource("Amazon.GameLift.ContainerGroupType")]
        public Amazon.GameLift.ContainerGroupType ContainerGroupType { get; set; }
        #endregion
        
        #region Parameter Limit
        /// <summary>
        /// <para>
        /// <para>The maximum number of results to return. Use this parameter with <c>NextToken</c>
        /// to get results as a set of sequential pages.</para>
        /// </para>
        /// </summary>
        [System.Management.Automation.Parameter(ValueFromPipelineByPropertyName = true)]
        public System.Int32? Limit { get; set; }
        #endregion
        
        #region Parameter NextToken
        /// <summary>
        /// <para>
        /// <para>A token that indicates the start of the next sequential page of results. Use the token
        /// that is returned with a previous call to this operation. To start at the beginning
        /// of the result set, do not specify a value.</para>
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
        /// Use the -Select parameter to control the cmdlet output. The default value is 'ContainerGroupDefinitions'.
        /// Specifying -Select '*' will result in the cmdlet returning the whole service response (Amazon.GameLift.Model.ListContainerGroupDefinitionsResponse).
        /// Specifying the name of a property of type Amazon.GameLift.Model.ListContainerGroupDefinitionsResponse will result in that property being returned.
        /// Specifying -Select '^ParameterName' will result in the cmdlet returning the selected cmdlet parameter value.
        /// </summary>
        [System.Management.Automation.Parameter(ValueFromPipelineByPropertyName = true)]
        public string Select { get; set; } = "ContainerGroupDefinitions";
        #endregion
        
        #region Parameter PassThru
        /// <summary>
        /// Changes the cmdlet behavior to return the value passed to the ContainerGroupType parameter.
        /// The -PassThru parameter is deprecated, use -Select '^ContainerGroupType' instead. This parameter will be removed in a future version.
        /// </summary>
        [System.Obsolete("The -PassThru parameter is deprecated, use -Select '^ContainerGroupType' instead. This parameter will be removed in a future version.")]
        [System.Management.Automation.Parameter(ValueFromPipelineByPropertyName = true)]
        public SwitchParameter PassThru { get; set; }
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
                context.Select = CreateSelectDelegate<Amazon.GameLift.Model.ListContainerGroupDefinitionsResponse, GetGMLContainerGroupDefinitionListCmdlet>(Select) ??
                    throw new System.ArgumentException("Invalid value for -Select parameter.", nameof(this.Select));
                if (this.PassThru.IsPresent)
                {
                    throw new System.ArgumentException("-PassThru cannot be used when -Select is specified.", nameof(this.Select));
                }
            }
            else if (this.PassThru.IsPresent)
            {
                context.Select = (response, cmdlet) => this.ContainerGroupType;
            }
            #pragma warning restore CS0618, CS0612 //A class member was marked with the Obsolete attribute
            context.ContainerGroupType = this.ContainerGroupType;
            context.Limit = this.Limit;
            context.NextToken = this.NextToken;
            
            // allow further manipulation of loaded context prior to processing
            PostExecutionContextLoad(context);
            
            var output = Execute(context) as CmdletOutput;
            ProcessOutput(output);
        }
        
        #region IExecutor Members
        
        public object Execute(ExecutorContext context)
        {
            var cmdletContext = context as CmdletContext;
            #pragma warning disable CS0618, CS0612 //A class member was marked with the Obsolete attribute
            var useParameterSelect = this.Select.StartsWith("^") || this.PassThru.IsPresent;
            #pragma warning restore CS0618, CS0612 //A class member was marked with the Obsolete attribute
            
            // create request and set iteration invariants
            var request = new Amazon.GameLift.Model.ListContainerGroupDefinitionsRequest();
            
            if (cmdletContext.ContainerGroupType != null)
            {
                request.ContainerGroupType = cmdletContext.ContainerGroupType;
            }
            if (cmdletContext.Limit != null)
            {
                request.Limit = cmdletContext.Limit.Value;
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
        
        private Amazon.GameLift.Model.ListContainerGroupDefinitionsResponse CallAWSServiceOperation(IAmazonGameLift client, Amazon.GameLift.Model.ListContainerGroupDefinitionsRequest request)
        {
            Utils.Common.WriteVerboseEndpointMessage(this, client.Config, "Amazon GameLift Service", "ListContainerGroupDefinitions");
            try
            {
                #if DESKTOP
                return client.ListContainerGroupDefinitions(request);
                #elif CORECLR
                return client.ListContainerGroupDefinitionsAsync(request).GetAwaiter().GetResult();
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
            public Amazon.GameLift.ContainerGroupType ContainerGroupType { get; set; }
            public System.Int32? Limit { get; set; }
            public System.String NextToken { get; set; }
            public System.Func<Amazon.GameLift.Model.ListContainerGroupDefinitionsResponse, GetGMLContainerGroupDefinitionListCmdlet, object> Select { get; set; } =
                (response, cmdlet) => response.ContainerGroupDefinitions;
        }
        
    }
}
