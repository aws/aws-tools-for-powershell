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
using Amazon.Route53;
using Amazon.Route53.Model;

namespace Amazon.PowerShell.Cmdlets.R53
{
    /// <summary>
    /// Returns a paginated list of CIDR collections in the Amazon Web Services account (metadata
    /// only).
    /// </summary>
    [Cmdlet("Get", "R53CidrCollectionList")]
    [OutputType("Amazon.Route53.Model.CollectionSummary")]
    [AWSCmdlet("Calls the Amazon Route 53 ListCidrCollections API operation.", Operation = new[] {"ListCidrCollections"}, SelectReturnType = typeof(Amazon.Route53.Model.ListCidrCollectionsResponse))]
    [AWSCmdletOutput("Amazon.Route53.Model.CollectionSummary or Amazon.Route53.Model.ListCidrCollectionsResponse",
        "This cmdlet returns a collection of Amazon.Route53.Model.CollectionSummary objects.",
        "The service call response (type Amazon.Route53.Model.ListCidrCollectionsResponse) can be returned by specifying '-Select *'."
    )]
    public partial class GetR53CidrCollectionListCmdlet : AmazonRoute53ClientCmdlet, IExecutor
    {
        
        protected override bool IsGeneratedCmdlet { get; set; } = true;
        
        #region Parameter MaxResult
        /// <summary>
        /// <para>
        /// <para>The maximum number of CIDR collections to return in the response.</para>
        /// </para>
        /// </summary>
        [System.Management.Automation.Parameter(ValueFromPipelineByPropertyName = true)]
        [Alias("MaxResults")]
        public System.String MaxResult { get; set; }
        #endregion
        
        #region Parameter NextToken
        /// <summary>
        /// <para>
        /// <para>An opaque pagination token to indicate where the service is to begin enumerating results.</para><para>If no value is provided, the listing of results starts from the beginning.</para>
        /// </para>
        /// </summary>
        [System.Management.Automation.Parameter(ValueFromPipelineByPropertyName = true)]
        public System.String NextToken { get; set; }
        #endregion
        
        #region Parameter Select
        /// <summary>
        /// Use the -Select parameter to control the cmdlet output. The default value is 'CidrCollections'.
        /// Specifying -Select '*' will result in the cmdlet returning the whole service response (Amazon.Route53.Model.ListCidrCollectionsResponse).
        /// Specifying the name of a property of type Amazon.Route53.Model.ListCidrCollectionsResponse will result in that property being returned.
        /// Specifying -Select '^ParameterName' will result in the cmdlet returning the selected cmdlet parameter value.
        /// </summary>
        [System.Management.Automation.Parameter(ValueFromPipelineByPropertyName = true)]
        public string Select { get; set; } = "CidrCollections";
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
                context.Select = CreateSelectDelegate<Amazon.Route53.Model.ListCidrCollectionsResponse, GetR53CidrCollectionListCmdlet>(Select) ??
                    throw new System.ArgumentException("Invalid value for -Select parameter.", nameof(this.Select));
            }
            context.NextToken = this.NextToken;
            context.MaxResult = this.MaxResult;
            
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
            var request = new Amazon.Route53.Model.ListCidrCollectionsRequest();
            
            if (cmdletContext.NextToken != null)
            {
                request.NextToken = cmdletContext.NextToken;
            }
            if (cmdletContext.MaxResult != null)
            {
                request.MaxResults = cmdletContext.MaxResult;
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
        
        private Amazon.Route53.Model.ListCidrCollectionsResponse CallAWSServiceOperation(IAmazonRoute53 client, Amazon.Route53.Model.ListCidrCollectionsRequest request)
        {
            Utils.Common.WriteVerboseEndpointMessage(this, client.Config, "Amazon Route 53", "ListCidrCollections");
            try
            {
                #if DESKTOP
                return client.ListCidrCollections(request);
                #elif CORECLR
                return client.ListCidrCollectionsAsync(request).GetAwaiter().GetResult();
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
            public System.String NextToken { get; set; }
            public System.String MaxResult { get; set; }
            public System.Func<Amazon.Route53.Model.ListCidrCollectionsResponse, GetR53CidrCollectionListCmdlet, object> Select { get; set; } =
                (response, cmdlet) => response.CidrCollections;
        }
        
    }
}
