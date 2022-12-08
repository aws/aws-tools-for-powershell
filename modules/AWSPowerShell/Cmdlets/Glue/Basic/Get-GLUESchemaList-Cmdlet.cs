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
using Amazon.Glue;
using Amazon.Glue.Model;

namespace Amazon.PowerShell.Cmdlets.GLUE
{
    /// <summary>
    /// Returns a list of schemas with minimal details. Schemas in Deleting status will not
    /// be included in the results. Empty results will be returned if there are no schemas
    /// available.
    /// 
    ///  
    /// <para>
    /// When the <code>RegistryId</code> is not provided, all the schemas across registries
    /// will be part of the API response.
    /// </para><br/><br/>This cmdlet automatically pages all available results to the pipeline - parameters related to iteration are only needed if you want to manually control the paginated output. To disable autopagination, use -NoAutoIteration.
    /// </summary>
    [Cmdlet("Get", "GLUESchemaList")]
    [OutputType("Amazon.Glue.Model.SchemaListItem")]
    [AWSCmdlet("Calls the AWS Glue ListSchemas API operation.", Operation = new[] {"ListSchemas"}, SelectReturnType = typeof(Amazon.Glue.Model.ListSchemasResponse))]
    [AWSCmdletOutput("Amazon.Glue.Model.SchemaListItem or Amazon.Glue.Model.ListSchemasResponse",
        "This cmdlet returns a collection of Amazon.Glue.Model.SchemaListItem objects.",
        "The service call response (type Amazon.Glue.Model.ListSchemasResponse) can also be referenced from properties attached to the cmdlet entry in the $AWSHistory stack."
    )]
    public partial class GetGLUESchemaListCmdlet : AmazonGlueClientCmdlet, IExecutor
    {
        
        #region Parameter RegistryId_RegistryArn
        /// <summary>
        /// <para>
        /// <para>Arn of the registry to be updated. One of <code>RegistryArn</code> or <code>RegistryName</code>
        /// has to be provided.</para>
        /// </para>
        /// </summary>
        [System.Management.Automation.Parameter(ValueFromPipelineByPropertyName = true)]
        public System.String RegistryId_RegistryArn { get; set; }
        #endregion
        
        #region Parameter RegistryId_RegistryName
        /// <summary>
        /// <para>
        /// <para>Name of the registry. Used only for lookup. One of <code>RegistryArn</code> or <code>RegistryName</code>
        /// has to be provided. </para>
        /// </para>
        /// </summary>
        [System.Management.Automation.Parameter(ValueFromPipelineByPropertyName = true)]
        public System.String RegistryId_RegistryName { get; set; }
        #endregion
        
        #region Parameter MaxResult
        /// <summary>
        /// <para>
        /// <para>Maximum number of results required per page. If the value is not supplied, this will
        /// be defaulted to 25 per page.</para>
        /// </para>
        /// </summary>
        [System.Management.Automation.Parameter(ValueFromPipelineByPropertyName = true)]
        [Alias("MaxResults")]
        public System.Int32? MaxResult { get; set; }
        #endregion
        
        #region Parameter NextToken
        /// <summary>
        /// <para>
        /// <para>A continuation token, if this is a continuation call.</para>
        /// </para>
        /// <para>
        /// <br/><b>Note:</b> This parameter is only used if you are manually controlling output pagination of the service API call.
        /// <br/>In order to manually control output pagination, use '-NextToken $null' for the first call and '-NextToken $AWSHistory.LastServiceResponse.NextToken' for subsequent calls.
        /// </para>
        /// </summary>
        [System.Management.Automation.Parameter(ValueFromPipelineByPropertyName = true)]
        public System.String NextToken { get; set; }
        #endregion
        
        #region Parameter Select
        /// <summary>
        /// Use the -Select parameter to control the cmdlet output. The default value is 'Schemas'.
        /// Specifying -Select '*' will result in the cmdlet returning the whole service response (Amazon.Glue.Model.ListSchemasResponse).
        /// Specifying the name of a property of type Amazon.Glue.Model.ListSchemasResponse will result in that property being returned.
        /// Specifying -Select '^ParameterName' will result in the cmdlet returning the selected cmdlet parameter value.
        /// </summary>
        [System.Management.Automation.Parameter(ValueFromPipelineByPropertyName = true)]
        public string Select { get; set; } = "Schemas";
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
            
            if (ParameterWasBound(nameof(this.Select)))
            {
                context.Select = CreateSelectDelegate<Amazon.Glue.Model.ListSchemasResponse, GetGLUESchemaListCmdlet>(Select) ??
                    throw new System.ArgumentException("Invalid value for -Select parameter.", nameof(this.Select));
            }
            context.MaxResult = this.MaxResult;
            context.NextToken = this.NextToken;
            context.RegistryId_RegistryArn = this.RegistryId_RegistryArn;
            context.RegistryId_RegistryName = this.RegistryId_RegistryName;
            
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
            var request = new Amazon.Glue.Model.ListSchemasRequest();
            
            if (cmdletContext.MaxResult != null)
            {
                request.MaxResults = cmdletContext.MaxResult.Value;
            }
            
             // populate RegistryId
            var requestRegistryIdIsNull = true;
            request.RegistryId = new Amazon.Glue.Model.RegistryId();
            System.String requestRegistryId_registryId_RegistryArn = null;
            if (cmdletContext.RegistryId_RegistryArn != null)
            {
                requestRegistryId_registryId_RegistryArn = cmdletContext.RegistryId_RegistryArn;
            }
            if (requestRegistryId_registryId_RegistryArn != null)
            {
                request.RegistryId.RegistryArn = requestRegistryId_registryId_RegistryArn;
                requestRegistryIdIsNull = false;
            }
            System.String requestRegistryId_registryId_RegistryName = null;
            if (cmdletContext.RegistryId_RegistryName != null)
            {
                requestRegistryId_registryId_RegistryName = cmdletContext.RegistryId_RegistryName;
            }
            if (requestRegistryId_registryId_RegistryName != null)
            {
                request.RegistryId.RegistryName = requestRegistryId_registryId_RegistryName;
                requestRegistryIdIsNull = false;
            }
             // determine if request.RegistryId should be set to null
            if (requestRegistryIdIsNull)
            {
                request.RegistryId = null;
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
        
        private Amazon.Glue.Model.ListSchemasResponse CallAWSServiceOperation(IAmazonGlue client, Amazon.Glue.Model.ListSchemasRequest request)
        {
            Utils.Common.WriteVerboseEndpointMessage(this, client.Config, "AWS Glue", "ListSchemas");
            try
            {
                #if DESKTOP
                return client.ListSchemas(request);
                #elif CORECLR
                return client.ListSchemasAsync(request).GetAwaiter().GetResult();
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
            public System.Int32? MaxResult { get; set; }
            public System.String NextToken { get; set; }
            public System.String RegistryId_RegistryArn { get; set; }
            public System.String RegistryId_RegistryName { get; set; }
            public System.Func<Amazon.Glue.Model.ListSchemasResponse, GetGLUESchemaListCmdlet, object> Select { get; set; } =
                (response, cmdlet) => response.Schemas;
        }
        
    }
}
