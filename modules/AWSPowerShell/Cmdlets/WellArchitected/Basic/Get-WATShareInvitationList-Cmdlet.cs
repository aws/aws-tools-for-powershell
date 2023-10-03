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
using Amazon.WellArchitected;
using Amazon.WellArchitected.Model;

namespace Amazon.PowerShell.Cmdlets.WAT
{
    /// <summary>
    /// List the share invitations.
    /// 
    ///  
    /// <para><code>WorkloadNamePrefix</code>, <code>LensNamePrefix</code>, <code>ProfileNamePrefix</code>,
    /// and <code>TemplateNamePrefix</code> are mutually exclusive. Use the parameter that
    /// matches your <code>ShareResourceType</code>.
    /// </para>
    /// </summary>
    [Cmdlet("Get", "WATShareInvitationList")]
    [OutputType("Amazon.WellArchitected.Model.ShareInvitationSummary")]
    [AWSCmdlet("Calls the AWS Well-Architected Tool ListShareInvitations API operation.", Operation = new[] {"ListShareInvitations"}, SelectReturnType = typeof(Amazon.WellArchitected.Model.ListShareInvitationsResponse))]
    [AWSCmdletOutput("Amazon.WellArchitected.Model.ShareInvitationSummary or Amazon.WellArchitected.Model.ListShareInvitationsResponse",
        "This cmdlet returns a collection of Amazon.WellArchitected.Model.ShareInvitationSummary objects.",
        "The service call response (type Amazon.WellArchitected.Model.ListShareInvitationsResponse) can also be referenced from properties attached to the cmdlet entry in the $AWSHistory stack."
    )]
    public partial class GetWATShareInvitationListCmdlet : AmazonWellArchitectedClientCmdlet, IExecutor
    {
        
        protected override bool IsGeneratedCmdlet { get; set; } = true;
        
        #region Parameter LensNamePrefix
        /// <summary>
        /// <para>
        /// <para>An optional string added to the beginning of each lens name returned in the results.</para>
        /// </para>
        /// </summary>
        [System.Management.Automation.Parameter(ValueFromPipelineByPropertyName = true)]
        public System.String LensNamePrefix { get; set; }
        #endregion
        
        #region Parameter ProfileNamePrefix
        /// <summary>
        /// <para>
        /// <para>An optional string added to the beginning of each profile name returned in the results.</para>
        /// </para>
        /// </summary>
        [System.Management.Automation.Parameter(ValueFromPipelineByPropertyName = true)]
        public System.String ProfileNamePrefix { get; set; }
        #endregion
        
        #region Parameter ShareResourceType
        /// <summary>
        /// <para>
        /// <para>The type of share invitations to be returned.</para>
        /// </para>
        /// </summary>
        [System.Management.Automation.Parameter(ValueFromPipelineByPropertyName = true)]
        [AWSConstantClassSource("Amazon.WellArchitected.ShareResourceType")]
        public Amazon.WellArchitected.ShareResourceType ShareResourceType { get; set; }
        #endregion
        
        #region Parameter TemplateNamePrefix
        /// <summary>
        /// <para>
        /// <para>An optional string added to the beginning of each review template name returned in
        /// the results.</para>
        /// </para>
        /// </summary>
        [System.Management.Automation.Parameter(ValueFromPipelineByPropertyName = true)]
        public System.String TemplateNamePrefix { get; set; }
        #endregion
        
        #region Parameter WorkloadNamePrefix
        /// <summary>
        /// <para>
        /// The service has not provided documentation for this parameter; please refer to the service's API reference documentation for the latest available information.
        /// </para>
        /// </summary>
        [System.Management.Automation.Parameter(Position = 0, ValueFromPipelineByPropertyName = true, ValueFromPipeline = true)]
        public System.String WorkloadNamePrefix { get; set; }
        #endregion
        
        #region Parameter MaxResult
        /// <summary>
        /// <para>
        /// <para>The maximum number of results to return for this request.</para>
        /// </para>
        /// </summary>
        [System.Management.Automation.Parameter(ValueFromPipelineByPropertyName = true)]
        [Alias("MaxResults")]
        public System.Int32? MaxResult { get; set; }
        #endregion
        
        #region Parameter NextToken
        /// <summary>
        /// <para>
        /// The service has not provided documentation for this parameter; please refer to the service's API reference documentation for the latest available information.
        /// </para>
        /// </summary>
        [System.Management.Automation.Parameter(ValueFromPipelineByPropertyName = true)]
        public System.String NextToken { get; set; }
        #endregion
        
        #region Parameter Select
        /// <summary>
        /// Use the -Select parameter to control the cmdlet output. The default value is 'ShareInvitationSummaries'.
        /// Specifying -Select '*' will result in the cmdlet returning the whole service response (Amazon.WellArchitected.Model.ListShareInvitationsResponse).
        /// Specifying the name of a property of type Amazon.WellArchitected.Model.ListShareInvitationsResponse will result in that property being returned.
        /// Specifying -Select '^ParameterName' will result in the cmdlet returning the selected cmdlet parameter value.
        /// </summary>
        [System.Management.Automation.Parameter(ValueFromPipelineByPropertyName = true)]
        public string Select { get; set; } = "ShareInvitationSummaries";
        #endregion
        
        #region Parameter PassThru
        /// <summary>
        /// Changes the cmdlet behavior to return the value passed to the WorkloadNamePrefix parameter.
        /// The -PassThru parameter is deprecated, use -Select '^WorkloadNamePrefix' instead. This parameter will be removed in a future version.
        /// </summary>
        [System.Obsolete("The -PassThru parameter is deprecated, use -Select '^WorkloadNamePrefix' instead. This parameter will be removed in a future version.")]
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
                context.Select = CreateSelectDelegate<Amazon.WellArchitected.Model.ListShareInvitationsResponse, GetWATShareInvitationListCmdlet>(Select) ??
                    throw new System.ArgumentException("Invalid value for -Select parameter.", nameof(this.Select));
                if (this.PassThru.IsPresent)
                {
                    throw new System.ArgumentException("-PassThru cannot be used when -Select is specified.", nameof(this.Select));
                }
            }
            else if (this.PassThru.IsPresent)
            {
                context.Select = (response, cmdlet) => this.WorkloadNamePrefix;
            }
            #pragma warning restore CS0618, CS0612 //A class member was marked with the Obsolete attribute
            context.LensNamePrefix = this.LensNamePrefix;
            context.MaxResult = this.MaxResult;
            context.NextToken = this.NextToken;
            context.ProfileNamePrefix = this.ProfileNamePrefix;
            context.ShareResourceType = this.ShareResourceType;
            context.TemplateNamePrefix = this.TemplateNamePrefix;
            context.WorkloadNamePrefix = this.WorkloadNamePrefix;
            
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
            var request = new Amazon.WellArchitected.Model.ListShareInvitationsRequest();
            
            if (cmdletContext.LensNamePrefix != null)
            {
                request.LensNamePrefix = cmdletContext.LensNamePrefix;
            }
            if (cmdletContext.MaxResult != null)
            {
                request.MaxResults = cmdletContext.MaxResult.Value;
            }
            if (cmdletContext.NextToken != null)
            {
                request.NextToken = cmdletContext.NextToken;
            }
            if (cmdletContext.ProfileNamePrefix != null)
            {
                request.ProfileNamePrefix = cmdletContext.ProfileNamePrefix;
            }
            if (cmdletContext.ShareResourceType != null)
            {
                request.ShareResourceType = cmdletContext.ShareResourceType;
            }
            if (cmdletContext.TemplateNamePrefix != null)
            {
                request.TemplateNamePrefix = cmdletContext.TemplateNamePrefix;
            }
            if (cmdletContext.WorkloadNamePrefix != null)
            {
                request.WorkloadNamePrefix = cmdletContext.WorkloadNamePrefix;
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
        
        private Amazon.WellArchitected.Model.ListShareInvitationsResponse CallAWSServiceOperation(IAmazonWellArchitected client, Amazon.WellArchitected.Model.ListShareInvitationsRequest request)
        {
            Utils.Common.WriteVerboseEndpointMessage(this, client.Config, "AWS Well-Architected Tool", "ListShareInvitations");
            try
            {
                #if DESKTOP
                return client.ListShareInvitations(request);
                #elif CORECLR
                return client.ListShareInvitationsAsync(request).GetAwaiter().GetResult();
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
            public System.String LensNamePrefix { get; set; }
            public System.Int32? MaxResult { get; set; }
            public System.String NextToken { get; set; }
            public System.String ProfileNamePrefix { get; set; }
            public Amazon.WellArchitected.ShareResourceType ShareResourceType { get; set; }
            public System.String TemplateNamePrefix { get; set; }
            public System.String WorkloadNamePrefix { get; set; }
            public System.Func<Amazon.WellArchitected.Model.ListShareInvitationsResponse, GetWATShareInvitationListCmdlet, object> Select { get; set; } =
                (response, cmdlet) => response.ShareInvitationSummaries;
        }
        
    }
}
