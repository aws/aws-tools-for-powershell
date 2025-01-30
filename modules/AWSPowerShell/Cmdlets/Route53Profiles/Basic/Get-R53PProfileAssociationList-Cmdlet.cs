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
using Amazon.Route53Profiles;
using Amazon.Route53Profiles.Model;

namespace Amazon.PowerShell.Cmdlets.R53P
{
    /// <summary>
    /// Lists all the VPCs that the specified Route 53 Profile is associated with.
    /// </summary>
    [Cmdlet("Get", "R53PProfileAssociationList")]
    [OutputType("Amazon.Route53Profiles.Model.ProfileAssociation")]
    [AWSCmdlet("Calls the Amazon Route 53 Profiles ListProfileAssociations API operation.", Operation = new[] {"ListProfileAssociations"}, SelectReturnType = typeof(Amazon.Route53Profiles.Model.ListProfileAssociationsResponse))]
    [AWSCmdletOutput("Amazon.Route53Profiles.Model.ProfileAssociation or Amazon.Route53Profiles.Model.ListProfileAssociationsResponse",
        "This cmdlet returns a collection of Amazon.Route53Profiles.Model.ProfileAssociation objects.",
        "The service call response (type Amazon.Route53Profiles.Model.ListProfileAssociationsResponse) can be returned by specifying '-Select *'."
    )]
    public partial class GetR53PProfileAssociationListCmdlet : AmazonRoute53ProfilesClientCmdlet, IExecutor
    {
        
        protected override bool IsGeneratedCmdlet { get; set; } = true;
        
        #region Parameter ProfileId
        /// <summary>
        /// <para>
        /// <para> ID of the Profile. </para>
        /// </para>
        /// </summary>
        [System.Management.Automation.Parameter(Position = 0, ValueFromPipelineByPropertyName = true, ValueFromPipeline = true)]
        public System.String ProfileId { get; set; }
        #endregion
        
        #region Parameter ResourceId
        /// <summary>
        /// <para>
        /// <para> ID of the VPC. </para>
        /// </para>
        /// </summary>
        [System.Management.Automation.Parameter(ValueFromPipelineByPropertyName = true)]
        public System.String ResourceId { get; set; }
        #endregion
        
        #region Parameter MaxResult
        /// <summary>
        /// <para>
        /// <para> The maximum number of objects that you want to return for this request. If more objects
        /// are available, in the response, a <c>NextToken</c> value, which you can use in a subsequent
        /// call to get the next batch of objects, is provided.</para><para> If you don't specify a value for <c>MaxResults</c>, up to 100 objects are returned.
        /// </para>
        /// </para>
        /// </summary>
        [System.Management.Automation.Parameter(ValueFromPipelineByPropertyName = true)]
        [Alias("MaxResults")]
        public System.Int32? MaxResult { get; set; }
        #endregion
        
        #region Parameter NextToken
        /// <summary>
        /// <para>
        /// <para> For the first call to this list request, omit this value. </para><para>When you request a list of objects, at most the number of objects specified by <c>MaxResults</c>
        /// is returned. If more objects are available for retrieval, a <c>NextToken</c> value
        /// is returned in the response. To retrieve the next batch of objects, use the token
        /// that was returned for the prior request in your next request.</para>
        /// </para>
        /// </summary>
        [System.Management.Automation.Parameter(ValueFromPipelineByPropertyName = true)]
        public System.String NextToken { get; set; }
        #endregion
        
        #region Parameter Select
        /// <summary>
        /// Use the -Select parameter to control the cmdlet output. The default value is 'ProfileAssociations'.
        /// Specifying -Select '*' will result in the cmdlet returning the whole service response (Amazon.Route53Profiles.Model.ListProfileAssociationsResponse).
        /// Specifying the name of a property of type Amazon.Route53Profiles.Model.ListProfileAssociationsResponse will result in that property being returned.
        /// Specifying -Select '^ParameterName' will result in the cmdlet returning the selected cmdlet parameter value.
        /// </summary>
        [System.Management.Automation.Parameter(ValueFromPipelineByPropertyName = true)]
        public string Select { get; set; } = "ProfileAssociations";
        #endregion
        
        #region Parameter PassThru
        /// <summary>
        /// Changes the cmdlet behavior to return the value passed to the ProfileId parameter.
        /// The -PassThru parameter is deprecated, use -Select '^ProfileId' instead. This parameter will be removed in a future version.
        /// </summary>
        [System.Obsolete("The -PassThru parameter is deprecated, use -Select '^ProfileId' instead. This parameter will be removed in a future version.")]
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
                context.Select = CreateSelectDelegate<Amazon.Route53Profiles.Model.ListProfileAssociationsResponse, GetR53PProfileAssociationListCmdlet>(Select) ??
                    throw new System.ArgumentException("Invalid value for -Select parameter.", nameof(this.Select));
                if (this.PassThru.IsPresent)
                {
                    throw new System.ArgumentException("-PassThru cannot be used when -Select is specified.", nameof(this.Select));
                }
            }
            else if (this.PassThru.IsPresent)
            {
                context.Select = (response, cmdlet) => this.ProfileId;
            }
            #pragma warning restore CS0618, CS0612 //A class member was marked with the Obsolete attribute
            context.MaxResult = this.MaxResult;
            context.NextToken = this.NextToken;
            context.ProfileId = this.ProfileId;
            context.ResourceId = this.ResourceId;
            
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
            var request = new Amazon.Route53Profiles.Model.ListProfileAssociationsRequest();
            
            if (cmdletContext.MaxResult != null)
            {
                request.MaxResults = cmdletContext.MaxResult.Value;
            }
            if (cmdletContext.NextToken != null)
            {
                request.NextToken = cmdletContext.NextToken;
            }
            if (cmdletContext.ProfileId != null)
            {
                request.ProfileId = cmdletContext.ProfileId;
            }
            if (cmdletContext.ResourceId != null)
            {
                request.ResourceId = cmdletContext.ResourceId;
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
        
        private Amazon.Route53Profiles.Model.ListProfileAssociationsResponse CallAWSServiceOperation(IAmazonRoute53Profiles client, Amazon.Route53Profiles.Model.ListProfileAssociationsRequest request)
        {
            Utils.Common.WriteVerboseEndpointMessage(this, client.Config, "Amazon Route 53 Profiles", "ListProfileAssociations");
            try
            {
                #if DESKTOP
                return client.ListProfileAssociations(request);
                #elif CORECLR
                return client.ListProfileAssociationsAsync(request).GetAwaiter().GetResult();
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
            public System.String ProfileId { get; set; }
            public System.String ResourceId { get; set; }
            public System.Func<Amazon.Route53Profiles.Model.ListProfileAssociationsResponse, GetR53PProfileAssociationListCmdlet, object> Select { get; set; } =
                (response, cmdlet) => response.ProfileAssociations;
        }
        
    }
}
