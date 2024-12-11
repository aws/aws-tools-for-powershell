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
    /// Returns a list of schema versions that you have created, with minimal information.
    /// Schema versions in Deleted status will not be included in the results. Empty results
    /// will be returned if there are no schema versions available.<br/><br/>This cmdlet automatically pages all available results to the pipeline - parameters related to iteration are only needed if you want to manually control the paginated output. To disable autopagination, use -NoAutoIteration.
    /// </summary>
    [Cmdlet("Get", "GLUESchemaVersionList")]
    [OutputType("Amazon.Glue.Model.SchemaVersionListItem")]
    [AWSCmdlet("Calls the AWS Glue ListSchemaVersions API operation.", Operation = new[] {"ListSchemaVersions"}, SelectReturnType = typeof(Amazon.Glue.Model.ListSchemaVersionsResponse))]
    [AWSCmdletOutput("Amazon.Glue.Model.SchemaVersionListItem or Amazon.Glue.Model.ListSchemaVersionsResponse",
        "This cmdlet returns a collection of Amazon.Glue.Model.SchemaVersionListItem objects.",
        "The service call response (type Amazon.Glue.Model.ListSchemaVersionsResponse) can be returned by specifying '-Select *'."
    )]
    public partial class GetGLUESchemaVersionListCmdlet : AmazonGlueClientCmdlet, IExecutor
    {
        
        protected override bool IsGeneratedCmdlet { get; set; } = true;
        
        #region Parameter SchemaId_RegistryName
        /// <summary>
        /// <para>
        /// <para>The name of the schema registry that contains the schema.</para>
        /// </para>
        /// </summary>
        [System.Management.Automation.Parameter(ValueFromPipelineByPropertyName = true)]
        public System.String SchemaId_RegistryName { get; set; }
        #endregion
        
        #region Parameter SchemaId_SchemaArn
        /// <summary>
        /// <para>
        /// <para>The Amazon Resource Name (ARN) of the schema. One of <c>SchemaArn</c> or <c>SchemaName</c>
        /// has to be provided.</para>
        /// </para>
        /// </summary>
        [System.Management.Automation.Parameter(Position = 0, ValueFromPipelineByPropertyName = true, ValueFromPipeline = true)]
        public System.String SchemaId_SchemaArn { get; set; }
        #endregion
        
        #region Parameter SchemaId_SchemaName
        /// <summary>
        /// <para>
        /// <para>The name of the schema. One of <c>SchemaArn</c> or <c>SchemaName</c> has to be provided.</para>
        /// </para>
        /// </summary>
        [System.Management.Automation.Parameter(ValueFromPipelineByPropertyName = true)]
        public System.String SchemaId_SchemaName { get; set; }
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
        /// <br/>'NextToken' is only returned by the cmdlet when '-Select *' is specified. In order to manually control output pagination, set '-NextToken' to null for the first call then set the 'NextToken' using the same property output from the previous call for subsequent calls.
        /// </para>
        /// </summary>
        [System.Management.Automation.Parameter(ValueFromPipelineByPropertyName = true)]
        public System.String NextToken { get; set; }
        #endregion
        
        #region Parameter Select
        /// <summary>
        /// Use the -Select parameter to control the cmdlet output. The default value is 'Schemas'.
        /// Specifying -Select '*' will result in the cmdlet returning the whole service response (Amazon.Glue.Model.ListSchemaVersionsResponse).
        /// Specifying the name of a property of type Amazon.Glue.Model.ListSchemaVersionsResponse will result in that property being returned.
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
                context.Select = CreateSelectDelegate<Amazon.Glue.Model.ListSchemaVersionsResponse, GetGLUESchemaVersionListCmdlet>(Select) ??
                    throw new System.ArgumentException("Invalid value for -Select parameter.", nameof(this.Select));
            }
            context.MaxResult = this.MaxResult;
            context.NextToken = this.NextToken;
            context.SchemaId_RegistryName = this.SchemaId_RegistryName;
            context.SchemaId_SchemaArn = this.SchemaId_SchemaArn;
            context.SchemaId_SchemaName = this.SchemaId_SchemaName;
            
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
            var request = new Amazon.Glue.Model.ListSchemaVersionsRequest();
            
            if (cmdletContext.MaxResult != null)
            {
                request.MaxResults = cmdletContext.MaxResult.Value;
            }
            
             // populate SchemaId
            var requestSchemaIdIsNull = true;
            request.SchemaId = new Amazon.Glue.Model.SchemaId();
            System.String requestSchemaId_schemaId_RegistryName = null;
            if (cmdletContext.SchemaId_RegistryName != null)
            {
                requestSchemaId_schemaId_RegistryName = cmdletContext.SchemaId_RegistryName;
            }
            if (requestSchemaId_schemaId_RegistryName != null)
            {
                request.SchemaId.RegistryName = requestSchemaId_schemaId_RegistryName;
                requestSchemaIdIsNull = false;
            }
            System.String requestSchemaId_schemaId_SchemaArn = null;
            if (cmdletContext.SchemaId_SchemaArn != null)
            {
                requestSchemaId_schemaId_SchemaArn = cmdletContext.SchemaId_SchemaArn;
            }
            if (requestSchemaId_schemaId_SchemaArn != null)
            {
                request.SchemaId.SchemaArn = requestSchemaId_schemaId_SchemaArn;
                requestSchemaIdIsNull = false;
            }
            System.String requestSchemaId_schemaId_SchemaName = null;
            if (cmdletContext.SchemaId_SchemaName != null)
            {
                requestSchemaId_schemaId_SchemaName = cmdletContext.SchemaId_SchemaName;
            }
            if (requestSchemaId_schemaId_SchemaName != null)
            {
                request.SchemaId.SchemaName = requestSchemaId_schemaId_SchemaName;
                requestSchemaIdIsNull = false;
            }
             // determine if request.SchemaId should be set to null
            if (requestSchemaIdIsNull)
            {
                request.SchemaId = null;
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
        
        private Amazon.Glue.Model.ListSchemaVersionsResponse CallAWSServiceOperation(IAmazonGlue client, Amazon.Glue.Model.ListSchemaVersionsRequest request)
        {
            Utils.Common.WriteVerboseEndpointMessage(this, client.Config, "AWS Glue", "ListSchemaVersions");
            try
            {
                #if DESKTOP
                return client.ListSchemaVersions(request);
                #elif CORECLR
                return client.ListSchemaVersionsAsync(request).GetAwaiter().GetResult();
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
            public System.String SchemaId_RegistryName { get; set; }
            public System.String SchemaId_SchemaArn { get; set; }
            public System.String SchemaId_SchemaName { get; set; }
            public System.Func<Amazon.Glue.Model.ListSchemaVersionsResponse, GetGLUESchemaVersionListCmdlet, object> Select { get; set; } =
                (response, cmdlet) => response.Schemas;
        }
        
    }
}
