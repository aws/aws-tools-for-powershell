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
using Amazon.CloudTrail;
using Amazon.CloudTrail.Model;

namespace Amazon.PowerShell.Cmdlets.CT
{
    /// <summary>
    /// Retrieves settings for one or more trails associated with the current Region for your
    /// account.
    /// </summary>
    [Cmdlet("Get", "CTTrail")]
    [OutputType("Amazon.CloudTrail.Model.Trail")]
    [AWSCmdlet("Calls the AWS CloudTrail DescribeTrails API operation.", Operation = new[] {"DescribeTrails"}, SelectReturnType = typeof(Amazon.CloudTrail.Model.DescribeTrailsResponse))]
    [AWSCmdletOutput("Amazon.CloudTrail.Model.Trail or Amazon.CloudTrail.Model.DescribeTrailsResponse",
        "This cmdlet returns a collection of Amazon.CloudTrail.Model.Trail objects.",
        "The service call response (type Amazon.CloudTrail.Model.DescribeTrailsResponse) can also be referenced from properties attached to the cmdlet entry in the $AWSHistory stack."
    )]
    public partial class GetCTTrailCmdlet : AmazonCloudTrailClientCmdlet, IExecutor
    {
        
        protected override bool IsGeneratedCmdlet { get; set; } = true;
        
        #region Parameter IncludeShadowTrail
        /// <summary>
        /// <para>
        /// <para>Specifies whether to include shadow trails in the response. A shadow trail is the
        /// replication in a Region of a trail that was created in a different Region, or in the
        /// case of an organization trail, the replication of an organization trail in member
        /// accounts. If you do not include shadow trails, organization trails in a member account
        /// and Region replication trails will not be returned. The default is true.</para>
        /// </para>
        /// </summary>
        [System.Management.Automation.Parameter(Position = 1, ValueFromPipelineByPropertyName = true)]
        [Alias("IncludeShadowTrails")]
        public System.Boolean? IncludeShadowTrail { get; set; }
        #endregion
        
        #region Parameter TrailNameList
        /// <summary>
        /// <para>
        /// <para>Specifies a list of trail names, trail ARNs, or both, of the trails to describe. The
        /// format of a trail ARN is:</para><para><c>arn:aws:cloudtrail:us-east-2:123456789012:trail/MyTrail</c></para><para>If an empty list is specified, information for the trail in the current Region is
        /// returned.</para><ul><li><para>If an empty list is specified and <c>IncludeShadowTrails</c> is false, then information
        /// for all trails in the current Region is returned.</para></li><li><para>If an empty list is specified and IncludeShadowTrails is null or true, then information
        /// for all trails in the current Region and any associated shadow trails in other Regions
        /// is returned.</para></li></ul><note><para>If one or more trail names are specified, information is returned only if the names
        /// match the names of trails belonging only to the current Region and current account.
        /// To return information about a trail in another Region, you must specify its trail
        /// ARN.</para></note>
        /// </para>
        /// </summary>
        [System.Management.Automation.Parameter(Position = 0, ValueFromPipelineByPropertyName = true, ValueFromPipeline = true)]
        [Alias("Name")]
        public System.String[] TrailNameList { get; set; }
        #endregion
        
        #region Parameter Select
        /// <summary>
        /// Use the -Select parameter to control the cmdlet output. The default value is 'TrailList'.
        /// Specifying -Select '*' will result in the cmdlet returning the whole service response (Amazon.CloudTrail.Model.DescribeTrailsResponse).
        /// Specifying the name of a property of type Amazon.CloudTrail.Model.DescribeTrailsResponse will result in that property being returned.
        /// Specifying -Select '^ParameterName' will result in the cmdlet returning the selected cmdlet parameter value.
        /// </summary>
        [System.Management.Automation.Parameter(ValueFromPipelineByPropertyName = true)]
        public string Select { get; set; } = "TrailList";
        #endregion
        
        #region Parameter PassThru
        /// <summary>
        /// Changes the cmdlet behavior to return the value passed to the TrailNameList parameter.
        /// The -PassThru parameter is deprecated, use -Select '^TrailNameList' instead. This parameter will be removed in a future version.
        /// </summary>
        [System.Obsolete("The -PassThru parameter is deprecated, use -Select '^TrailNameList' instead. This parameter will be removed in a future version.")]
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
                context.Select = CreateSelectDelegate<Amazon.CloudTrail.Model.DescribeTrailsResponse, GetCTTrailCmdlet>(Select) ??
                    throw new System.ArgumentException("Invalid value for -Select parameter.", nameof(this.Select));
                if (this.PassThru.IsPresent)
                {
                    throw new System.ArgumentException("-PassThru cannot be used when -Select is specified.", nameof(this.Select));
                }
            }
            else if (this.PassThru.IsPresent)
            {
                context.Select = (response, cmdlet) => this.TrailNameList;
            }
            #pragma warning restore CS0618, CS0612 //A class member was marked with the Obsolete attribute
            context.IncludeShadowTrail = this.IncludeShadowTrail;
            if (this.TrailNameList != null)
            {
                context.TrailNameList = new List<System.String>(this.TrailNameList);
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
            var request = new Amazon.CloudTrail.Model.DescribeTrailsRequest();
            
            if (cmdletContext.IncludeShadowTrail != null)
            {
                request.IncludeShadowTrails = cmdletContext.IncludeShadowTrail.Value;
            }
            if (cmdletContext.TrailNameList != null)
            {
                request.TrailNameList = cmdletContext.TrailNameList;
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
        
        private Amazon.CloudTrail.Model.DescribeTrailsResponse CallAWSServiceOperation(IAmazonCloudTrail client, Amazon.CloudTrail.Model.DescribeTrailsRequest request)
        {
            Utils.Common.WriteVerboseEndpointMessage(this, client.Config, "AWS CloudTrail", "DescribeTrails");
            try
            {
                #if DESKTOP
                return client.DescribeTrails(request);
                #elif CORECLR
                return client.DescribeTrailsAsync(request).GetAwaiter().GetResult();
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
            public System.Boolean? IncludeShadowTrail { get; set; }
            public List<System.String> TrailNameList { get; set; }
            public System.Func<Amazon.CloudTrail.Model.DescribeTrailsResponse, GetCTTrailCmdlet, object> Select { get; set; } =
                (response, cmdlet) => response.TrailList;
        }
        
    }
}
