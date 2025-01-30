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
using Amazon.APIGateway;
using Amazon.APIGateway.Model;

namespace Amazon.PowerShell.Cmdlets.AG
{
    /// <summary>
    /// Represents a collection on DomainNameAccessAssociations resources.<br/><br/>This cmdlet automatically pages all available results to the pipeline - parameters related to iteration are only needed if you want to manually control the paginated output. To disable autopagination, use -NoAutoIteration.
    /// </summary>
    [Cmdlet("Get", "AGDomainNameAccessAssociation")]
    [OutputType("Amazon.APIGateway.Model.DomainNameAccessAssociation")]
    [AWSCmdlet("Calls the Amazon API Gateway GetDomainNameAccessAssociations API operation.", Operation = new[] {"GetDomainNameAccessAssociations"}, SelectReturnType = typeof(Amazon.APIGateway.Model.GetDomainNameAccessAssociationsResponse))]
    [AWSCmdletOutput("Amazon.APIGateway.Model.DomainNameAccessAssociation or Amazon.APIGateway.Model.GetDomainNameAccessAssociationsResponse",
        "This cmdlet returns a collection of Amazon.APIGateway.Model.DomainNameAccessAssociation objects.",
        "The service call response (type Amazon.APIGateway.Model.GetDomainNameAccessAssociationsResponse) can be returned by specifying '-Select *'."
    )]
    public partial class GetAGDomainNameAccessAssociationCmdlet : AmazonAPIGatewayClientCmdlet, IExecutor
    {
        
        protected override bool IsGeneratedCmdlet { get; set; } = true;
        
        #region Parameter ResourceOwner
        /// <summary>
        /// <para>
        /// <para> The owner of the domain name access association. Use <c>SELF</c> to only list the
        /// domain name access associations owned by your own account. Use <c>OTHER_ACCOUNTS</c>
        /// to list the domain name access associations with your private custom domain names
        /// that are owned by other AWS accounts.</para>
        /// </para>
        /// </summary>
        [System.Management.Automation.Parameter(Position = 0, ValueFromPipelineByPropertyName = true, ValueFromPipeline = true)]
        [AWSConstantClassSource("Amazon.APIGateway.ResourceOwner")]
        public Amazon.APIGateway.ResourceOwner ResourceOwner { get; set; }
        #endregion
        
        #region Parameter Limit
        /// <summary>
        /// <para>
        /// <para>The maximum number of returned results per page. The default value is 25 and the maximum
        /// value is 500. </para>
        /// </para>
        /// </summary>
        [System.Management.Automation.Parameter(ValueFromPipelineByPropertyName = true)]
        public System.Int32? Limit { get; set; }
        #endregion
        
        #region Parameter Position
        /// <summary>
        /// <para>
        /// <para>The current pagination position in the paged result set. </para>
        /// </para>
        /// <para>
        /// <br/><b>Note:</b> This parameter is only used if you are manually controlling output pagination of the service API call.
        /// <br/>'Position' is only returned by the cmdlet when '-Select *' is specified. In order to manually control output pagination, set '-Position' to null for the first call then set the 'Position' using the same property output from the previous call for subsequent calls.
        /// </para>
        /// </summary>
        [System.Management.Automation.Parameter(ValueFromPipelineByPropertyName = true)]
        [Alias("NextToken")]
        public System.String Position { get; set; }
        #endregion
        
        #region Parameter Select
        /// <summary>
        /// Use the -Select parameter to control the cmdlet output. The default value is 'Items'.
        /// Specifying -Select '*' will result in the cmdlet returning the whole service response (Amazon.APIGateway.Model.GetDomainNameAccessAssociationsResponse).
        /// Specifying the name of a property of type Amazon.APIGateway.Model.GetDomainNameAccessAssociationsResponse will result in that property being returned.
        /// Specifying -Select '^ParameterName' will result in the cmdlet returning the selected cmdlet parameter value.
        /// </summary>
        [System.Management.Automation.Parameter(ValueFromPipelineByPropertyName = true)]
        public string Select { get; set; } = "Items";
        #endregion
        
        #region Parameter PassThru
        /// <summary>
        /// Changes the cmdlet behavior to return the value passed to the ResourceOwner parameter.
        /// The -PassThru parameter is deprecated, use -Select '^ResourceOwner' instead. This parameter will be removed in a future version.
        /// </summary>
        [System.Obsolete("The -PassThru parameter is deprecated, use -Select '^ResourceOwner' instead. This parameter will be removed in a future version.")]
        [System.Management.Automation.Parameter(ValueFromPipelineByPropertyName = true)]
        public SwitchParameter PassThru { get; set; }
        #endregion
        
        #region Parameter NoAutoIteration
        /// <summary>
        /// By default the cmdlet will auto-iterate and retrieve all results to the pipeline by performing multiple
        /// service calls. If set, the cmdlet will retrieve only the next 'page' of results using the value of Position
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
                context.Select = CreateSelectDelegate<Amazon.APIGateway.Model.GetDomainNameAccessAssociationsResponse, GetAGDomainNameAccessAssociationCmdlet>(Select) ??
                    throw new System.ArgumentException("Invalid value for -Select parameter.", nameof(this.Select));
                if (this.PassThru.IsPresent)
                {
                    throw new System.ArgumentException("-PassThru cannot be used when -Select is specified.", nameof(this.Select));
                }
            }
            else if (this.PassThru.IsPresent)
            {
                context.Select = (response, cmdlet) => this.ResourceOwner;
            }
            #pragma warning restore CS0618, CS0612 //A class member was marked with the Obsolete attribute
            context.Limit = this.Limit;
            context.Position = this.Position;
            context.ResourceOwner = this.ResourceOwner;
            
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
            var request = new Amazon.APIGateway.Model.GetDomainNameAccessAssociationsRequest();
            
            if (cmdletContext.Limit != null)
            {
                request.Limit = cmdletContext.Limit.Value;
            }
            if (cmdletContext.ResourceOwner != null)
            {
                request.ResourceOwner = cmdletContext.ResourceOwner;
            }
            
            // Initialize loop variant and commence piping
            var _nextToken = cmdletContext.Position;
            var _userControllingPaging = this.NoAutoIteration.IsPresent || ParameterWasBound(nameof(this.Position));
            
            var client = Client ?? CreateClient(_CurrentCredentials, _RegionEndpoint);
            do
            {
                request.Position = _nextToken;
                
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
                    
                    _nextToken = response.Position;
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
        
        private Amazon.APIGateway.Model.GetDomainNameAccessAssociationsResponse CallAWSServiceOperation(IAmazonAPIGateway client, Amazon.APIGateway.Model.GetDomainNameAccessAssociationsRequest request)
        {
            Utils.Common.WriteVerboseEndpointMessage(this, client.Config, "Amazon API Gateway", "GetDomainNameAccessAssociations");
            try
            {
                #if DESKTOP
                return client.GetDomainNameAccessAssociations(request);
                #elif CORECLR
                return client.GetDomainNameAccessAssociationsAsync(request).GetAwaiter().GetResult();
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
            public System.Int32? Limit { get; set; }
            public System.String Position { get; set; }
            public Amazon.APIGateway.ResourceOwner ResourceOwner { get; set; }
            public System.Func<Amazon.APIGateway.Model.GetDomainNameAccessAssociationsResponse, GetAGDomainNameAccessAssociationCmdlet, object> Select { get; set; } =
                (response, cmdlet) => response.Items;
        }
        
    }
}
